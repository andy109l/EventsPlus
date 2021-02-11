using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlus.Models
{
    public class VenueAddress
    {
        [Key]
        public int ID { get; set; }

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
        [StringLength(15)]
        [Display(Name = "Postcode ID")]
        public int PosCitCouPostcode { get; set; }

        public PosCitCou PosCitCou { get; set; }
    }
}
