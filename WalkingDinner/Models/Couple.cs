using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WalkingDinner.Models
{
    public class Couple
    {
        public int CoupleId { get; set; }
        [Required]
        public Person Person1 { get; set; }
        public Person Person2 { get; set; }
    }
}