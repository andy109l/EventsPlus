using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsPlus.Models;

namespace EventsPlus.ViewModels
{
    /// <summary>
    /// Containter for multiple modles that could be used in a single views
    /// </summary>
    public class EventAttendees
    {
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<GuestAttendee> GuestAttendees { get; set; }
    }
}
