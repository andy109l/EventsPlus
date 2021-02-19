using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsPlus.Controllers;
using EventsPlus.Data;
using EventsPlus.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using XUnitTestEventsPlus.Utilities;

namespace XUnitTestEventsPlus.Controllers
{
    public class EventsContollerTest : TestControllerBase
    {

        [Fact]
        public void Index_ReturnsAViewResult()
        {
            //Arrange 
            EventsController eventsController = new EventsController(context);

            //Act
            var result = eventsController.Index(null, "", "", null);

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void Details_ReturnsAViewResult()
        {
            //Arrange 
            EventsController eventsController = new EventsController(context);

            //Act
            var result = await eventsController.Details(1);

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(9000)]
        public async void Details_ReturnsANotFoundResult(int? eventId)
        {
            //Arrange 
            EventsController eventsController = new EventsController(context);

            //Act
            var result = await eventsController.Details(eventId);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Create_ReturnsAViewResult()
        {
            //Arrange 
            EventsController eventsController = new EventsController(context);

            //Act
            var result = eventsController.Create();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void CreateAdd_RedirectToActionResult()
        {
            //Arrange 
            EventsController eventsController = new EventsController(context);

            //Act
            var result = await eventsController.Create(new Event()
            {
                Id = 2,
                OrganizerId = 1,
                EventsStartTime = DateTime.Now,
                EventsStartEnd = DateTime.Now,
                NumberOfAttendies = 12,
                PrivacySetting = true,
                VerifiedOnly = true,
                EventTypeId = 1,
                VenueAddressId = 1
            });

            //Assert
            Assert.IsType<RedirectToActionResult>(result);
        }
        //Failed Validation
        public async void CreateAdd_ReturnsAViewResult()
        {
            //Arrange 
            EventsController eventsController = new EventsController(context);

            //Act
            var result = await eventsController.Create(new Event()
            {
                Id = 1,
                OrganizerId = 1,
                EventsStartTime = DateTime.Now,
                EventsStartEnd = DateTime.Now,
                NumberOfAttendies = 12,
                PrivacySetting = true,
                VerifiedOnly = true,
                EventTypeId = 1,
            });

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(9000)]
        public async void Edit_ReturnsANotFoundResult(int? eventId)
        {
            //Arrange 
            EventsController eventsController = new EventsController(context);

            //Act
            var result = await eventsController.Edit(eventId);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void Edit_ReturnsAViewResult()
        {
            //Arrange 
            EventsController eventsController = new EventsController(context);

            //Act
            var result = await eventsController.Edit(1);

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void Edit_Post_ReturnsANotFoundResult()
        {
            //Arrange 
            EventsController eventsController = new EventsController(context);

            //Act
            var result = await eventsController.Edit(2, new Event());

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void Edit_Post_RedirectToActionResult()
        {
            //Arrange 
            EventsController eventsController = new EventsController(context);

            //Act
            var result = await eventsController.Edit(1, context.Event.First());
            //Assert
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public async void Edit_Post_ReturnsANotFoundEventResult()
        {
            //Arrange 
            EventsController eventsController = new EventsController(context);
            //Act
            var result = await eventsController.Edit(2, new Event() 
            {
                Id = 2
            });
            //Assert
            Assert.IsType<NotFoundResult>(result);
        }


        [Theory]
        [InlineData(null)]
        [InlineData(9000)]
        public async void Delete_ReturnsANotFoundResult(int? eventId)
        {
            //Arrange 
            EventsController eventsController = new EventsController(context);

            //Act
            var result = await eventsController.Delete(eventId);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void Delete_Confirm_RedirectToActionResult()
        {
            //Arrange 
            EventsController eventsController = new EventsController(context);

            //Act
            var result = await eventsController.DeleteConfirmed(1);
            //Assert
            Assert.IsType<RedirectToActionResult>(result);
        }

    }
}
