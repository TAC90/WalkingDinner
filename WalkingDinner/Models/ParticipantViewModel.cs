using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WalkingDinner.DAL;

namespace WalkingDinner.Models
{
    [NotMapped]
    public class ParticipantViewModel
    {
        public Participant Participant { get; set; }
        private WDContext db = new WDContext();
        public ParticipantViewModel()
        {
        }
        public ParticipantViewModel(Participant p)
        {
            Participant = p;
        }
        public ICollection<Schedule> AllSchedules {
            get {
                return db.Schedules.Where(s => s.Active == true).ToList();
            }
        }
    }
}