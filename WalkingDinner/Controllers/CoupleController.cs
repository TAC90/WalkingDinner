using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WalkingDinner.DAL;
using WalkingDinner.Models;

namespace WalkingDinner.Controllers
{
    public class CoupleController : Controller
    {
        private WDContext db = new WDContext();

        // GET: Couple
        public ActionResult Index()
        {
            return View(db.Couples.ToList());
        }

        // GET: Couple/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Couple couple = db.Couples.Find(id);
            if (couple == null)
            {
                return HttpNotFound();
            }
            return View(couple);
        }

        // GET: Couple/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Couple/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CoupleID")] Couple couple)
        {
            if (ModelState.IsValid)
            {
                db.Couples.Add(couple);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(couple);
        }

        // GET: Couple/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Couple couple = db.Couples.Find(id);
            if (couple == null)
            {
                return HttpNotFound();
            }
            return View(couple);
        }

        // POST: Couple/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CoupleID")] Couple couple)
        {
            if (ModelState.IsValid)
            {
                db.Entry(couple).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(couple);
        }

        // GET: Couple/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Couple couple = db.Couples.Find(id);
            if (couple == null)
            {
                return HttpNotFound();
            }
            return View(couple);
        }

        // POST: Couple/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Couple couple = db.Couples.Find(id);
            db.Couples.Remove(couple);
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
