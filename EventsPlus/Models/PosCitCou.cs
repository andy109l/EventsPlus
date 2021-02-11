using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlus.Models
{
    public class PosCitCou
    {
        [Key]
        [Display(Name = "Postcode ID")]
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Postcode")]
        public string Postcode { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z\s]{1,40}$", ErrorMessage = " Up to 20 latin uppercase and lowercase characters are allowed.")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z\s]{1,40}$", ErrorMessage = " Up to 20 latin uppercase and lowercase characters are allowed.")]
        [Display(Name = "Country")]
        public string Country { get; set; }

        public ICollection<Organizer> Organizers { get; set; }

        public ICollection<User> Users { get; set; }

        public ICollection<VenueAddress> VenueAddresses { get; set; }

        public ICollection<GuestAttendee> GuestAttendees { get; set; }


    }
}
