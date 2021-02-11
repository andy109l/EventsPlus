using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlus.Models
{
    public class GuestRegEvent
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Events ID")]
        public int EventsID { get; set; }

        public Event Event { get; set; }

        [Display(Name = "Guest Attendy ID")]
        public int GeuestAttendyID { get; set; }

        public GuestAttendee GuestAttendy { get; set; }

        [Display(Name = "Date of Registration")]
        public DateTime RegistrationTime { get; set; }

    }
}
