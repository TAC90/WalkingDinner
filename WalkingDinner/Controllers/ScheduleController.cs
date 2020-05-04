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
using WalkingDinner.ViewModels;

namespace WalkingDinner.Controllers
{
    public class ScheduleController : Controller
    {
        private WDContext db = new WDContext();

        // GET: Schedule
        public ActionResult Index()
        {
            return View(db.Schedules.Where(s => s.MaxParticipants > s.Participants.Count && s.Active == true).ToList());
        }
        
        // GET: Schedule/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedules.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // GET: Schedule/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Schedule/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ScheduleID,Title,Date,GroupSize,MaxCouples")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                db.Schedules.Add(schedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(schedule);
        }

        // GET: Schedule/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedules.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // POST: Schedule/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ScheduleID,Title,Date,GroupSize,MaxCouples")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(schedule);
        }

        // GET: Schedule/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedules.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // POST: Schedule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Schedule schedule = db.Schedules.Find(id);
            db.Schedules.Remove(schedule);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Schedule/Program/5
        public ActionResult Program(int? id)
        {
            var schedule = db.Schedules.FirstOrDefault(s => s.ScheduleID == id);
            if (schedule != null) {
                var viewmodel = new ProgramViewModel()
                {
                    Participants = schedule.Participants,
                    GroupSize = schedule.GroupSize,
                    ScheduleTitle = schedule.Title,
                    ScheduleID = schedule.ScheduleID
                };
                return View(viewmodel);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Program(FormCollection fc)
        {
            var x = TempData["Test"];
            //TODO: Fix Tempdata or find another way to send to controller with js, use ajax
            var y = TempData["programSubmit"];
            //string program = Request["programSubmit"];
            //string program = fc.Get(0);
            //var keys = fc.AllKeys;
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
