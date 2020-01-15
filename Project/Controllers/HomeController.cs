using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private SBS_RoboticEntities db = new SBS_RoboticEntities();

        // GET: Home
        public ActionResult Index()
        {
            return View(db.Masterials.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Masterial masterial = db.Masterials.Find(id);
            if (masterial == null)
            {
                return HttpNotFound();
            }
            return View(masterial);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PurchaseID,No,Name,Category,Color_Principle,Grain,Thickness,Quantity,Description,Dimention_Weight,Note")] Masterial masterial)
        {
            masterial.No = 1;
            if (ModelState.IsValid)
            {
                db.Masterials.Add(masterial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(masterial);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Masterial masterial = db.Masterials.Find(id);
            if (masterial == null)
            {
                return HttpNotFound();
            }
            return View(masterial);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PurchaseID,No,Name,Category,Color_Principle,Grain,Thickness,Quantity,Description,Dimention_Weight,Note")] Masterial masterial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(masterial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(masterial);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Masterial masterial = db.Masterials.Find(id);
            if (masterial == null)
            {
                return HttpNotFound();
            }
            return View(masterial);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Masterial masterial = db.Masterials.Find(id);
            db.Masterials.Remove(masterial);
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
        /*private void autagen(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select isnull(max(cast(No as int),0)+1)",con);
        }*/
    }
}
