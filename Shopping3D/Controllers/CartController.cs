using Shopping3D.Models;
using System;
using MercadoPago;
using MercadoPago.DataStructures.Preference;
using MercadoPago.Resources;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopping3D.Controllers
{
    public class CartController : Controller
    {
        private DbContexto db = new DbContexto();

        public ActionResult Index()
        {
            return View(Session["Cart"]);
        }

        [HttpPost]
        public ActionResult Checkout(string email) {
            MercadoPago.SDK.ClientId = "3120485104106115";
            MercadoPago.SDK.ClientSecret = "QRjZLfXx5FWgcxynmlrEik8dsrpHKpGX";
            
            if (Session["Cart"] != null) {
                Session["Client"] = email;
                Preference preference = new Preference();
                foreach (var item in Session["Cart"] as List<SaleLine>)
                {
                    preference.Items.Add(
                    new Item()
                      {
                          Id = item.Id.ToString(),
                          Title = item.Product.Name,
                          Quantity = item.ProductQuantity,
                          CurrencyId = (MercadoPago.Common.CurrencyId)item.Product.Currency,
                          UnitPrice = item.Product.Price
                      }
                    );
                }
                // Setting a payer object as value for Payer property
                preference.Payer = new Payer()
                {
                    Email = email.ToString()
                };
                // Save and posting preference
                BackUrls backUrls = new BackUrls();
                backUrls.Success = "http://localhost:50266/Cart/Callback";
                preference.BackUrls = backUrls;
                preference.Save();
                return Redirect(preference.SandboxInitPoint);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Callback() {
            return View();
        }

        // POST: Cart
        [HttpPost]
        public ActionResult Add(int id, int quantity)
        {
            Product Product = db.Products.Find(id);
            if (Session["Cart"] == null)
            {
                List<SaleLine> SaleLines = new List<SaleLine>();
                SaleLine SaleLine = new SaleLine(Product, quantity, quantity * Product.Price );
                SaleLines.Add(SaleLine);
                Session["Cart"] = SaleLines;
            }
            else {
                List<SaleLine> SaleLines = (List<SaleLine>)Session["Cart"];
                int productExist = existProduct(id);
                if (productExist != -1)
                {
                    SaleLine TargetSaleLine = SaleLines[productExist];
                    TargetSaleLine.ProductQuantity += quantity;
                    TargetSaleLine.SubTotal = TargetSaleLine.ProductQuantity * Product.Price;
                } else
                {
                    SaleLine SaleLine = new SaleLine(Product, quantity, quantity * Product.Price);
                    SaleLines.Add(SaleLine);
                }
                
                
            }

            return RedirectToAction("Index");
        }

        private int existProduct(int id) {
            List<SaleLine> SaleLines = (List<SaleLine>)Session["Cart"];
            for (int i = 0; i < SaleLines.Count; i++) {
                if (SaleLines[i].Product.Id == id) {
                    return i;
                }
            }
            return -1;
        }
    }
}