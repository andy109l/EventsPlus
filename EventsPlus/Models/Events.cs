using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlus.Models
{
    public class Events
    {
        [Required]
        [Display(Name = "Events ID")]
        public int EventsID { get; set; }
        [Required]
        [ForeignKey]
        [Display(Name = "Organizer ID")]
        public string OrganizerID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Events Start Time")]
        public string EventsStartTime { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Events Start End")]
        public string EventsStartEnd { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Number Of Attendies")]
        public string NumberOfAttendies { get; set; }
        [Display(Name = "Privacy Setting")]
        public string PrivacySetting { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Verified Only")]
        public string VerifiedOnly { get; set; }
        [Required]
        [ForeignKey]
        [StringLength(50)]
        [Display(Name = "Event Type ID")]
        public string EventTypeID { get; set; }
        [Required]
        [ForeignKey]
        [StringLength(50)]
        [Display(Name = "Venue Address ID")]
        public string VenueAddressID { get; set; }
    }
