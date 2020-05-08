using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Middle Name / Preposition")]
        public string MiddleName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Partner First Name")]
        public string FirstNamePartner { get; set; }
        [DisplayName("Partner Middle Name / Preposition")]
        public string MiddleNamePartner { get; set; }
        [DisplayName("Partner Last Name")]
        public string LastNamePartner { get; set; }
        [RegularExpression(@"^\d{4}[ -]?[A-Z]{2}$",
            ErrorMessage = "Please enter a valid Zip Code")]
        [Required]
        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }
        [Required]
        [DisplayName("Address")]
        public string Address { get; set; }
        [Required]
        [DisplayName("City")]
        public string City { get; set; }
        [RegularExpression(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\.\/0-9]*$",
            ErrorMessage = "Please enter a valid Phone Number")]
        [Required]
        [DisplayName("Telephone Number")]
        public string TelephoneNumber { get; set; }
        [DisplayName("Dietary Wishes/Comments")]
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
                if (!string.IsNullOrEmpty(FirstNamePartner))
                {
                    return $"{FirstNamePartner} {LastNamePartner}";
                }
                else
                {
                    return "N/A";
                }
            }
        }
        [NotMapped]
        public string CoupleName
        {
            get {
                if (!string.IsNullOrEmpty(FirstNamePartner))
                {
                    return $"{FirstName} & {FirstNamePartner}";
                }
                else
                {
                    return FirstName;
                }
            }
        }
    }
}