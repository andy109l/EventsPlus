using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlus.Models
{
    public class UserRegEvent
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Event ID")]
        public int EventID { get; set; }

        public Event Event { get; set; }

        [Display(Name = "User ID")]
        public int UserID { get; set; }

        public User User { get; set; }

        [Display(Name = "Date of Registration")]
        public DateTime RegistrationTime { get; set; }
    }
}
