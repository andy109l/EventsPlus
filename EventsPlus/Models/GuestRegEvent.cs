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
        public int Id { get; set; }

        [Required]
        [Display(Name = "Events ID")]
        public int EventId { get; set; }
        public Event Event { get; set; }

        [Required]
        [Display(Name = "Guest Attendee ID")]
        public int GuestAttendeeId { get; set; }
        public GuestAttendee GuestAttendee { get; set; }

        [Display(Name = "Date of Registration")]
        public DateTime RegistrationTime { get; set; }

    }
}
