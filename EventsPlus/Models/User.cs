using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EventsPlus.Models
{
    public class User : IdentityUser
    {

        [RegularExpression(@"^[a-zA-Z\s]{1,30}$", ErrorMessage = " Up to 30 latin uppercase and lowercase characters are allowed.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]{1,30}$", ErrorMessage = " Up to 30 latin uppercase and lowercase characters are allowed.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        public ICollection<UserRegEvent> UserRegEvents { get; set; }
    }
}
