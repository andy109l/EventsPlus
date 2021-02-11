using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlus.Data
{
   public class DbInitializer
    {
        /// <summary>
        /// Ensures that the data base is created, if not database and schema are created
        /// </summary>
        /// <param name="context"></param>
       public static void Initialize(ApplicationDbContext context)
        {
           context.Database.EnsureCreated();
        }
    }
}
