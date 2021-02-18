using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsPlus.Models;

namespace EventsPlus.ViewModels
{
    public class EventOrganizers
    {
        public IEnumerable<Organizer> Organizers { get; set; }
        public IEnumerable<Event> Events { get; set; }

    }
}
