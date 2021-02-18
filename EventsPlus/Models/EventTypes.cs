using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlus.Models
{
    public class EventTypes
    {
        [Key]
        [Display(Name = "Event Type ID")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Event Type")]
        public string Type { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
