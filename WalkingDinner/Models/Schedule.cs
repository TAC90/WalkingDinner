﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WalkingDinner.Models
{
    public class Schedule
    {
        public Schedule()
        {
            this.Participants = new HashSet<Participant>();
        }
        public int ScheduleID { get; set; }
        public bool Active { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime? Date { get; set; }
        [Required]
        public int GroupSize { get; set; }
        [Required]
        public int MaxParticipants { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
        public Dictionary<int, int> Course { get; set; } //Id as schedule + ParticipantId
    }
}

// Group size is the same as the amount of courses
// Amount of couples dictates the amount of parallel hosts