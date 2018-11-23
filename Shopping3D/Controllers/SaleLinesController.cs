using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shopping3D.Models;

namespace Shopping3D.Controllers
{
    public class SaleLinesController : Controller
    {
        private DbContexto db = new DbContexto();

        // GET: SaleLines
        public ActionResult Index()
        {
            return View(db.SaleLines.ToList());
        }

        // GET: SaleLines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleLine saleLine = db.SaleLines.Find(id);
            if (saleLine == null)
            {
                return HttpNotFound();
            }
            return View(saleLine);
        }

        // GET: SaleLines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SaleLines/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductQuantity,SubTotal")] SaleLine saleLine)
        {
            if (ModelState.IsValid)
            {
                db.SaleLines.Add(saleLine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(saleLine);
        }

        // GET: SaleLines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleLine saleLine = db.SaleLines.Find(id);
            if (saleLine == null)
            {
                return HttpNotFound();
            }
            return View(saleLine);
        }

        // POST: SaleLines/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductQuantity,SubTotal")] SaleLine saleLine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(saleLine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(saleLine);
        }

        // GET: SaleLines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleLine saleLine = db.SaleLines.Find(id);
            if (saleLine == null)
            {
                return HttpNotFound();
            }
            return View(saleLine);
        }

        // POST: SaleLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SaleLine saleLine = db.SaleLines.Find(id);
            db.SaleLines.Remove(saleLine);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
