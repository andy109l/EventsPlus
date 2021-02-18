using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlus.Models
{
    public class GuestAttendee
    {
        [Key]
        [Required]
        [Display(Name = "Guest Attendy ID")]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]{1,30}$", ErrorMessage = " Up to 30 latin uppercase and lowercase characters are allowed.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]{1,30}$", ErrorMessage = " Up to 30 latin uppercase and lowercase characters are allowed.")]
        [Column("First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[+][0-9\d]{1,15}", ErrorMessage = " Up to 15 characters from 0-9 with country code are required.")]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*@)[a-zA-Z\d].{1,40}$", ErrorMessage = " Up to 40 latin uppercase and lowercase characters with no spaces, as well as 0-9 digits in correct format are allowed.")]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Event ID")]
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
