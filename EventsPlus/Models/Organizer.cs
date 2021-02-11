using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlus.Models
{
    public class Organizer
    {
        [Key]
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z\s]{1,30}$", ErrorMessage = " Up to 30 latin uppercase and lowercase characters are allowed.")]
        [StringLength(30)]
        [Display(Name = "Organizer Last Name")]
        public string OrganizerLastName { get; set; }

        [RegularExpression(@"^[a-zA-Z\s]{1,30}$", ErrorMessage = " Up to 30 latin uppercase and lowercase characters are allowed.")]
        [Required]
        [StringLength(30)]
        [Column("FirstName")]
        [Display(Name = "Organizer First Name")]
        public string OrganizerFirstName { get; set; }

        [RegularExpression(@"^[+][0-9\d]{1,15}", ErrorMessage = " Up to 15 characters from 0-9 with country code are required.")]
        [Required]
        [StringLength(15, ErrorMessage = "Contact number cannot be longer than 15 characters.")]
        [Display(Name = "Organizer Contact Number")]
        public string OrganizerContactNumber { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*@)[a-zA-Z\d].{1,40}$", ErrorMessage = " Up to 40 latin uppercase and lowercase characters with no spaces, as well as 0-9 digits in correct format are allowed.")]
        [Display(Name = "Organizer Email Address")]
        public string OrganizerEmailAddress { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z\s\d]{1,40}$", ErrorMessage = " Up to 40 latin uppercase, lowercase and digit characters are allowed.")]
        [Display(Name = "Contact Address Line 1")]
        public string ContactAddressLine1 { get; set; }

        [RegularExpression(@"[a-zA-Z\s\d]{1,40}$", ErrorMessage = " Up to 40 latin uppercase, lowercase and digit characters are allowed.")]
        [Display(Name = "Contact Address Line 2")]
        public string ContactAddressLine2 { get; set; }

        [RegularExpression(@"[a-zA-Z\s\d]{1,40}$", ErrorMessage = " Up to 40 latin uppercase, lowercase and digit characters are allowed.")]
        [Display(Name = "Contact Address Line 3")]
        public string ContactAddressLine3 { get; set; }

        [RegularExpression(@"[a-zA-Z\s\d]{1,40}$", ErrorMessage = " Up to 40 latin uppercase, lowercase and digit characters are allowed.")]
        [Display(Name = "Contact Address Line 4")]
        public string ContactAddressLine4 { get; set; }

        [Required]
        [Display(Name = "Postcode ID")]
        public int PosCitCouId { get; set; }
        public PosCitCou PosCitCou { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
