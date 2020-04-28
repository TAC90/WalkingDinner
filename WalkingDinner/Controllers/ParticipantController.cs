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
    public class ParticipantController : Controller
    {
        private WDContext db = new WDContext();

        // GET: Participant
        public ActionResult Index()
        {
            return View(db.Participants.ToList());
        }

        // GET: Participant/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participant participant = db.Participants.Find(id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            //TODO Ad, Fix this
            //participant.Schedules = db.Schedules.Where(s => participant.Schedules.Contains(s)).ToList();
            return View(participant);
        }

        // GET: Participant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Participant/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ParticipantID,Solo,FirstName,MiddleName,LastName,FirstNamePartner,MiddleNamePartner,LastNamePartner,ZipCode,Address,City,TelephoneNumber,DietComments")] Participant participant)
        {
            //TODO: Schedule ID shennigans
            if (ModelState.IsValid && int.TryParse(Request.QueryString["scheduleId"], out int selectedID))
            {
                var schedule = db.Schedules.Find(selectedID);
                if (schedule != null) {
                    participant.Schedules.Add(schedule);
                    db.Participants.Add(participant);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Schedule");
                }
            }
            return View(participant);
            //TODO: Return possible Error?
        }

        // GET: Participant/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participant participant = db.Participants.Find(id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            return View(participant);
        }

        // POST: Participant/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParticipantID,Solo,FirstName,MiddleName,LastName,FirstNamePartner,MiddleNamePartner,LastNamePartner,ZipCode,Address,City,TelephoneNumber,DietComments")] Participant participant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(participant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(participant);
        }

        // GET: Participant/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participant participant = db.Participants.Find(id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            return View(participant);
        }

        // POST: Participant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Participant participant = db.Participants.Find(id);
            db.Participants.Remove(participant);
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
