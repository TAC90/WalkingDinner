using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WalkingDinner.Models
{
    public class Schedule
    {
        public int ScheduleID { get; set; }
        [Required]
        public int GroupSize { get; set; }
        [Required]
        public int MaxCouples { get; set; }
        public Dictionary<int, int> Course { get; set; } //Id as schedule + CoupleId
        public string Address { get; set; }
    }
}

// Group size is the same as the amount of courses
// Amount of couples dictates the amount of parallel hosts