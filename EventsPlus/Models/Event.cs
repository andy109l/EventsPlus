using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using EventsPlus.Enums;

namespace EventsPlus.Models
{
    public class Event
    {
        [Key]
        [Display(Name = "Event ID")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Organizer ID")]
        public int OrganizerId { get; set; }
        public Organizer Organizer { get; set; }

        [Required]
        [Display(Name = "Events Start Time")]
        public DateTime EventsStartTime { get; set; }

        [Required]
        [Display(Name = "Events Start End")]
        public DateTime EventsStartEnd { get; set; }

        [Required]
        [Display(Name = "Number Of Attendies")]
        public int NumberOfAttendies { get; set; }

        [Display(Name = "Privacy Setting")]
        public bool PrivacySetting { get; set; }

        [Required]
        [Display(Name = "Verified Only")]
        public bool VerifiedOnly { get; set; }

        [Required]
        [Display(Name = "Event Type")]
        public EventTypes EventType { get; set; }

        [Required]
        [Display(Name = "Venue Id")]
        public int VenueAddressId { get; set; }
        public VenueAddress VenueAddress { get; set; }

        public ICollection<GuestAttendee> GuestAttendees { get; set; }
    }
}
