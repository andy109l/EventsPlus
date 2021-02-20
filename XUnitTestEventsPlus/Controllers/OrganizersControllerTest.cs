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
    public class OrganizersControllerTest : TestControllerBase
    {
        [Fact]
        public async void Index_ReturnsAViewResult()
        {
            //Arrange 
            OrganizersController organizersController = new OrganizersController(context);

            //Act
            var result = await organizersController.Index(null, "", "", null);

            //Assert
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public async void Details_ReturnsAViewResult()
        {
            //Arrange 
            OrganizersController organizersController = new OrganizersController(context);

            //Act
            var result = await organizersController.Details(1);

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(9000)]
        public async void Details_ReturnsANotFoundResult(int? organizerId)
        {
            //Arrange 
            OrganizersController organizersController = new OrganizersController(context);

            //Act
            var result = await organizersController.Details(organizerId);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Create_ReturnsAViewResult()
        {
            //Arrange 
            OrganizersController organizersController = new OrganizersController(context);

            //Act
            var result = organizersController.Create();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void CreateAdd_RedirectToActionResult()
        {
            //Arrange 
            OrganizersController organizersController = new OrganizersController(context);

            //Act
            var result = await organizersController.Create(new Organizer()
            {
                Id = 2,
                OrganizerFirstName = "Andriy",
                OrganizerLastName = "Lysan",
                OrganizerContactNumber = "+447523543407",
                OrganizerEmailAddress = "andrLys@gmail.com"
            });

            //Assert
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(9000)]
        public async void Edit_ReturnsANotFoundResult(int? organizerId)
        {
            //Arrange 
            OrganizersController organizersController = new OrganizersController(context);

            //Act
            var result = await organizersController.Edit(organizerId);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void Edit_ReturnsAViewResult()
        {
            //Arrange 
            OrganizersController organizersController = new OrganizersController(context);

            //Act
            var result = await organizersController.Edit(1);

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void Edit_Post_ReturnsANotFoundResult()
        {
            //Arrange 
            OrganizersController organizersController = new OrganizersController(context);

            //Act
            var result = await organizersController.Edit(2, new Organizer());

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void Edit_Post_RedirectToActionResult()
        {
            //Arrange 
            OrganizersController organizersController = new OrganizersController(context);

            //Act
            var result = await organizersController.Edit(1, context.Organizer.First());
            //Assert
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public async void Edit_Post_ReturnsANotFoundEventResult()
        {
            //Arrange 
            OrganizersController organizersController = new OrganizersController(context);
            //Act
            var result = await organizersController.Edit(2, new Organizer()
            {
                Id = 2
            });
            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(9000)]
        public async void Delete_ReturnsANotFoundResult(int? organizerId)
        {
            //Arrange 
            OrganizersController organizersController = new OrganizersController(context);

            //Act
            var result = await organizersController.Delete(organizerId);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void Delete_Confirm_RedirectToActionResult()
        {
            //Arrange 
            OrganizersController organizersController = new OrganizersController(context);

            //Act
            var result = await organizersController.DeleteConfirmed(1);
            //Assert
            Assert.IsType<RedirectToActionResult>(result);
        }
    }
}
