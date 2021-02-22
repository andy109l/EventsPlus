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
    /// Unit test for the VenueAddress controller, checks if the methods in the controller behave as intended when you insert data into them and return correct data
    /// </summary>

    public class VenueAddressTest : TestControllerBase
    {
        [Fact]
        public async void Index_ReturnsAViewResult()
        {
            //Arrange 
            VenueAddressesController venueAddressesController = new VenueAddressesController(context);

            //Act
            var result = await venueAddressesController.Index(null, "", "", null);

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void Details_ReturnsAViewResult()
        {
            //Arrange 
            VenueAddressesController venueAddressesController = new VenueAddressesController(context);

            //Act
            var result = await venueAddressesController.Details(1);

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(9000)]
        public async void Details_ReturnsANotFoundResult(int? venueAddressId)
        {
            //Arrange 
            VenueAddressesController venueAddressesController = new VenueAddressesController(context);

            //Act
            var result = await venueAddressesController.Details(venueAddressId);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Create_ReturnsAViewResult()
        {
            //Arrange 
            VenueAddressesController venueAddressesController = new VenueAddressesController(context);

            //Act
            var result = venueAddressesController.Create();

            //Assert
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public async void CreateAdd_RedirectToActionResult()
        {
            //Arrange 
            VenueAddressesController venueAddressesController = new VenueAddressesController(context);

            //Act
            var result = await venueAddressesController.Create(new VenueAddress()
            {
                Id = 2,
                ContactAddressLine1 = "155 Adress",
                ContactAddressLine2 = "012 Address",
                ContactAddressLine3 = "Lot Par",
                ContactAddressLine4 = "",
                Postcode = "CDE 371",
                City = "Lorks",
                Country = "Ukraine"
            });

            //Assert
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(9000)]
        public async void Edit_ReturnsANotFoundResult(int? venueAddressId)
        {
            //Arrange 
            VenueAddressesController venueAddressesController = new VenueAddressesController(context);

            //Act
            var result = await venueAddressesController.Edit(venueAddressId);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }


        [Fact]
        public async void Edit_ReturnsAViewResult()
        {
            //Arrange 
            VenueAddressesController venueAddressesController = new VenueAddressesController(context);

            //Act
            var result = await venueAddressesController.Edit(1);

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void Edit_Post_ReturnsANotFoundResult()
        {
            //Arrange 
            VenueAddressesController venueAddressesController = new VenueAddressesController(context);

            //Act
            var result = await venueAddressesController.Edit(2, new VenueAddress());

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void Edit_Post_RedirectToActionResult()
        {
            //Arrange 
            VenueAddressesController venueAddressesController = new VenueAddressesController(context);

            //Act
            var result = await venueAddressesController.Edit(1, context.VenueAddress.First());
            //Assert
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public async void Edit_Post_ReturnsANotFoundEventResult()
        {
            //Arrange 
            VenueAddressesController venueAddressesController = new VenueAddressesController(context);
            //Act
            var result = await venueAddressesController.Edit(2, new VenueAddress()
            {
             Id = 2
            });
            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(9000)]
        public async void Delete_ReturnsANotFoundResult(int? venueAddressId)
        {
            //Arrange 
            VenueAddressesController venueAddressesController = new VenueAddressesController(context);

            //Act
            var result = await venueAddressesController.Delete(venueAddressId);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void Delete_Confirm_RedirectToActionResult()
        {
            //Arrange 
            VenueAddressesController venueAddressesController = new VenueAddressesController(context);

            //Act
            var result = await venueAddressesController.DeleteConfirmed(1);
            //Assert
            Assert.IsType<RedirectToActionResult>(result);
        }

    }
}
