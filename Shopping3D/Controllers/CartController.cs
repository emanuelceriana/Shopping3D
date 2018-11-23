using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopping3D.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Add()
        {
            if (Session["Cart"] == null) {

            }

            return View();
        }
    }
}