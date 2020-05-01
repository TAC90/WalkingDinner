using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WalkingDinner.DAL;
using WalkingDinner.Models;


namespace WalkingDinner.ViewModels
{
    public class ProgramViewModel
    {
        private WDContext db = new WDContext();
        public int ScheduleID { get; set; }
        public string ScheduleTitle { get; set; }
        public int GroupSize { get; set; }
        public ICollection<Participant> Participants { get; set; }

    }
}