using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsPlus.Models;

namespace EventsPlus.ViewModels
{
    public class EventAttendees
    {
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<GuestAttendee> GuestAttendees { get; set; }
    }
}
