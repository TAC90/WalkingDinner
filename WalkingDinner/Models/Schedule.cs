using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Title of Event")]
        public string Title { get; set; }
        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        [Required]
        [DisplayName("Group Size")]
        public int GroupSize { get; set; }
        [Required]
        [DisplayName("Maximum Participants")]
        public int MaxParticipants { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
        public string Program { get; set; }
        //public Dictionary<int, int> Program { get; set; } //Id as position + ParticipantId
        [NotMapped]
        public int AvailableSpace { get {
                return MaxParticipants - Participants.Count;
            }
        }
        [NotMapped]
        public int ParallelGroups { get {
                return Participants.Count / GroupSize;
            }
        }
    }
}

// Group size is the same as the amount of courses
// Amount of couples dictates the amount of parallel hosts