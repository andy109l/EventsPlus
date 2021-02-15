using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlus.Models
{
    public class UserRegEvent
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "Date of Registration")]
        public DateTime RegistrationTime { get; set; }
    }
}
