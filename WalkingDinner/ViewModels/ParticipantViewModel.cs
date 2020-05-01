using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WalkingDinner.DAL;
using WalkingDinner.Models;

namespace WalkingDinner.ViewModels
{
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
        public IEnumerable<int> CurrentSchedules { get {
                return Participant.Schedules.Select(s => s.ScheduleID).ToList();
            }
        }
        public ICollection<Schedule> AllSchedules {
            get {
                return db.Schedules.Where(s => s.Active == true).ToList();
            }
        }
    }
}