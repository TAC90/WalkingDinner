using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public Dictionary<int, int> Program { get; set; } //Id as position + ParticipantId
        [NotMapped]
        public int AvailableSpace { get {
                return MaxParticipants - Participants.Count;
            }
        }
    }
}

// Group size is the same as the amount of courses
// Amount of couples dictates the amount of parallel hosts