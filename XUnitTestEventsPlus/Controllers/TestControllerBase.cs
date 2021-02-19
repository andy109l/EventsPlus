using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsPlus.Data;
using XUnitTestEventsPlus.Utilities;

namespace XUnitTestEventsPlus.Controllers
{
    public abstract class TestControllerBase
    {
        protected ApplicationDbContext context;
        
        public TestControllerBase()
        {
            context = DbContextProvider.GetDbContext();
        }
    }
}
