using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsPlus.Data;
using Microsoft.EntityFrameworkCore;

namespace XUnitTestEventsPlus.Utilities
{
    class DbContextProvider
    {
    /// <summary>
    /// Provides the mocked DbContext for the Unit tests
    /// </summary>
    /// <returns></returns>
        public static ApplicationDbContext GetDbContext()
        {
            DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;

            ApplicationDbContext dbContext = new ApplicationDbContext(options);

            dbContext.AddRange(DbMockDataProvider.GetOrganizersData());
            dbContext.AddRange(DbMockDataProvider.GetVenueAddressData());
            dbContext.AddRange(DbMockDataProvider.GetEventTypeData());
            dbContext.AddRange(DbMockDataProvider.GetEventsData());
            dbContext.AddRange(DbMockDataProvider.GetGuestAttendeeData());

            dbContext.SaveChanges();

            return dbContext;
        }
    }
}
