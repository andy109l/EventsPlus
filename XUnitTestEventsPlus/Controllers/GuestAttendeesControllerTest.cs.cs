using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsPlus.Controllers;
using EventsPlus.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace XUnitTestEventsPlus.Controllers
{
    /// <summary>
    /// Unit test for the GuestAtteneeController, checks if the methods the in controller behave as intended when you insert data into them and return correct data
    /// </summary>
    public class GuestAttendeesControllerTest : TestControllerBase
    {
        [Fact]
        public async void Index_ReturnsAViewResult()
        {
            //Arrange 
            GuestAttendeesController guestAttendeesController = new GuestAttendeesController(context);

            //Act
            var result = await guestAttendeesController.Index(null, "", "", null);

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void Details_ReturnsAViewResult()
        {
            //Arrange 
            GuestAttendeesController guestAttendeesController = new GuestAttendeesController(context);

            //Act
            var result = await guestAttendeesController.Details(1);

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(9000)]
        public async void Details_ReturnsANotFoundResult(int? guestAttendeeId)
        {
            //Arrange 
            GuestAttendeesController guestAttendeesController = new GuestAttendeesController(context);

            //Act
            var result = await guestAttendeesController.Details(guestAttendeeId);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Create_ReturnsAViewResult()
        {
            //Arrange 
            GuestAttendeesController guestAttendeesController = new GuestAttendeesController(context);

            //Act
            var result = guestAttendeesController.Create();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void CreateAdd_RedirectToActionResult()
        {
            //Arrange 
            GuestAttendeesController guestAttendeesController = new GuestAttendeesController(context);

            //Act
            var result = await guestAttendeesController.Create(new GuestAttendee()
            {
                Id = 2,
                LastName = "Lycan",
                FirstName = "Loyd",
                ContactNumber = "+447575324574",
                EmailAddress = "lysAnd@gmail.com",
                EventId = 1,
            });

            //Assert
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(9000)]
        public async void Edit_ReturnsANotFoundResult(int? guestAttendeeId)
        {
            //Arrange 
            GuestAttendeesController guestAttendeesController = new GuestAttendeesController(context);

            //Act
            var result = await guestAttendeesController.Edit(guestAttendeeId);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void Edit_ReturnsAViewResult()
        {
            //Arrange 
            GuestAttendeesController guestAttendeesController = new GuestAttendeesController(context);

            //Act
            var result = await guestAttendeesController.Edit(1);

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void Edit_Post_ReturnsANotFoundResult()
        {
            //Arrange 
            GuestAttendeesController guestAttendeesController = new GuestAttendeesController(context);

            //Act
            var result = await guestAttendeesController.Edit(2, new GuestAttendee());

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void Edit_Post_RedirectToActionResult()
        {
            //Arrange 
            GuestAttendeesController guestAttendeesController = new GuestAttendeesController(context);

            //Act
            var result = await guestAttendeesController.Edit(1, context.GuestAttendee.First());
            //Assert
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public async void Edit_Post_ReturnsANotFoundEventResult()
        {
            //Arrange 
            GuestAttendeesController guestAttendeesController = new GuestAttendeesController(context);
            //Act
            var result = await guestAttendeesController.Edit(2, new GuestAttendee()
            {
                Id = 2
            });
            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(9000)]
        public async void Delete_ReturnsANotFoundResult(int? guestAttendeeId)
        {
            //Arrange 
            GuestAttendeesController guestAttendeesController = new GuestAttendeesController(context);

            //Act
            var result = await guestAttendeesController.Delete(guestAttendeeId);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void Delete_Confirm_RedirectToActionResult()
        {
            //Arrange 
            GuestAttendeesController guestAttendeesController = new GuestAttendeesController(context);

            //Act
            var result = await guestAttendeesController.DeleteConfirmed(1);
            //Assert
            Assert.IsType<RedirectToActionResult>(result);
        }
    }
}
