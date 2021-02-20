using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsPlus.Models;

namespace XUnitTestEventsPlus.Utilities
{
    public class DbMockDataProvider
    {
        public static List<Organizer> GetOrganizersData()
        {
            return new List<Organizer>
            {
                new Organizer
                {
                    Id = 1,
                    OrganizerFirstName = "Andriy",
                    OrganizerLastName = "Lysan",
                    OrganizerContactNumber = "+447523543407",
                    OrganizerEmailAddress = "andrLys@gmail.com"
                }
            };
        }

        public static List<VenueAddress> GetVenueAddressData()
        {
            return new List<VenueAddress>
            {
                new VenueAddress
                {
                    Id = 1,
                    ContactAddressLine1 = "MyContact 155 Adress",
                    ContactAddressLine2 = "17 012 Address",
                    ContactAddressLine3 = "Kyev Lot Par",
                    ContactAddressLine4 = "",
                    Postcode = "CDE 371",
                    City = "Kyiv",
                    Country = "Ukraine"
                }
            };
        }

        public static List<EventTypes> GetEventTypeData()
        {
            return new List<EventTypes>
            {
                new EventTypes
                {
                    Id = 1,
                    Type = "Festival"
                }
            };
        }



        public static List<Event> GetEventsData()
        {
            return new List<Event>
            {
                new Event
                {
                    Id = 1,
                    OrganizerId = 1,
                    EventsStartTime = DateTime.Now,
                    EventsStartEnd = DateTime.Now,
                    NumberOfAttendies = 17,
                    PrivacySetting = true,
                    VerifiedOnly = false,
                    EventTypeId = 1,
                    VenueAddressId = 1
                }
            };
        }

        public static List<GuestAttendee> GetGuestAttendeeData()
        {
            return new List<GuestAttendee>
            {
                new GuestAttendee
                {
                    Id = 1,
                    LastName = "Lycan",
                    FirstName = "Loyd",
                    ContactNumber = "+447575324574",
                    EmailAddress = "lysAnd@gmail.com",
                    EventId = 1,
                }
            };
        }
    }
}
