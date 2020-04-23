using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WalkingDinner.Models
{
    public class Couple
    {
        public int CoupleID { get; set; }
        [Required]
        public virtual Person Person1 { get; set; }
        public virtual Person Person2 { get; set; }
    }
}