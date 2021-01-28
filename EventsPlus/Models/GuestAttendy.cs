using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlus.Models
{
    public class GuestAttendy
    {
        [Required]
        [Display(Name = "Guest Attendy ID")]
        public int GeuestAttendyID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Contact Address Line 1")]
        public string ContactAddressLine1 { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Contact Address Line 2")]
        public string ContactAddressLine2 { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Contact Address Line 3")]
        public string ContactAddressLine3 { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Contact Address Line 4")]
        public string ContactAddressLine4 { get; set; }
        [Required]
        [ForeignKey]
        [StringLength(50)]
        [Display(Name = "Postcode ID")]
        public string PosCitCouPostcode { get; set; }
    }
}
