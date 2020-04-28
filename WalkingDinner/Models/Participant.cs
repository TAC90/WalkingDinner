using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WalkingDinner.Models
{
    public class Participant
    {
        public Participant()
        {
            this.Schedules = new HashSet<Schedule>();
        }
        public int ParticipantID { get; set; }
        [Required]
        public bool Solo { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string FirstNamePartner { get; set; }
        public string MiddleNamePartner { get; set; }
        public string LastNamePartner { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string TelephoneNumber { get; set; }
        public string DietComments { get; set; }

        [Required]
        public virtual ICollection<Schedule> Schedules { get; set; }

        [NotMapped]
        public string FullName
        {
            get {
                return $"{FirstName} {LastName}";
            }
        }
        [NotMapped]
        public string FullNamePartner
        {
            get {
                return $"{FirstNamePartner} {LastNamePartner}";
            }
        }
    }
}