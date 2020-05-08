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
            return View(db.Schedules.Where(s => s.Active == true && s.Date > DateTime.Now).ToList()); //s.MaxParticipants > s.Participants.Count
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
        public ActionResult Create([Bind(Include = "ScheduleID,Active,Title,Date,GroupSize,MaxParticipants")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                schedule.Active = true;
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
        public ActionResult Edit([Bind(Include = "ScheduleID,Active,Title,Date,GroupSize,MaxParticipants")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(schedule);
        }

        // GET: Schedule/Remove/5
        public ActionResult Remove(int? id)
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

        // POST: Schedule/Remove/5
        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveConfirmed(int id)
        {
            Schedule schedule = db.Schedules.Find(id);
            //db.Schedules.Remove(schedule);
            schedule.Active = false;
            db.SaveChanges();
            return RedirectToAction("Index");
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
                    MaxParticipants = schedule.MaxParticipants,
                    GroupSize = schedule.GroupSize,
                    ScheduleTitle = schedule.Title,
                    ScheduleID = schedule.ScheduleID,
                    Program = schedule.Program
                };
                return View(viewmodel);
            }
            return RedirectToAction("Index");
        }

        // POST: Schedule/Program/5
        [HttpPost]
        public ActionResult Program(string data)
        {
            //Data sample: 2|1:2,3:4,5:6,7:8
            List<string> dataList = data.Split('|').ToList();
            if(int.TryParse(dataList[0],out int scheduleId))
            {
                var schedule = db.Schedules.Find(scheduleId);
                schedule.Program = dataList[1];
                db.Entry(schedule).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                //TODO: Give back error?
            }
            //return RedirectToAction("Index"); //Does this even do anything with ajax?
            return Json(new { redirectToUrl = Url.Action("Index","Schedule") }); //Does this even do anything with ajax?
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
