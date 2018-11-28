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
            return View();
        }

        [HttpPost]
        public ActionResult Checkout([Bind(Include = "Email")] Client client) {
            if (!ModelState.IsValid)
            {
                return View("Index", client);
            }
            if (Session["Cart"] != null) {
                Session["Client"] = client;
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
                    Email = client.Email.ToString()
                };
                // Save and posting preference
                BackUrls backUrls = new BackUrls();
                backUrls.Success = "http://localhost:50266/Cart/SuccessCallback";
                backUrls.Pending = "http://localhost:50266/Cart/SuccessCallback";
                backUrls.Failure = "http://localhost:50266/Cart/FailureCallback";
                preference.BackUrls = backUrls;
                preference.Save();
                return Redirect(preference.SandboxInitPoint);
            }

            return RedirectToAction("Index");
        }

       
        public ActionResult SuccessCallback(int collection_id, string collection_status, string preference_id, string external_reference, string payment_type, int merchant_order_id) {
            Client Client = (Client)Session["Client"];
            decimal Total = 0;
            Sale Sale = new Sale();
            foreach (var SaleLine in Session["Cart"] as List<SaleLine>)
            {
                Total += SaleLine.SubTotal;
                SaleLine.Sale = Sale;
                db.SaleLines.Add(SaleLine);
            }
            Sale.Client = Client;
            Sale.Total = Total;
            Sale.Date = DateTime.Today;

            db.Clients.Add(Client);
            db.Sales.Add(Sale);
            db.SaveChanges();

            Session["Cart"] = null;
            Session["Client"] = null;
            return View("Index");
        }

        public ActionResult FailureCallback(int collection_id, string collection_status, string preference_id, string external_reference, string payment_type, int merchant_order_id)
        {
            return View("Index");
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
        
        
        public ActionResult Delete(int id)
        {
            var sLine = (List<SaleLine>)Session["Cart"];
            var objective = sLine.Find(item => item.Id == id);
            sLine.Remove(objective);

            return RedirectToAction("Index");
        }
    }
}