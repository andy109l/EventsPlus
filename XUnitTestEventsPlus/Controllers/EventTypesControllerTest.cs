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
    /// Unit test for the EventTypesController, checks if the methods the in controller behave as intended when you insert data into them and return correct data
    /// </summary>
    public class EventTypesControllerTest : TestControllerBase
    {

        [Fact]
        public async void Index_ReturnsAViewResult()
        {
            //Arrange 
            EventTypesController eventtypescontroller = new EventTypesController(context);

            //Act
            var result = await eventtypescontroller.Index(null, "", "", null);

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void Details_ReturnsAViewResult()
        {
            //Arrange 
            EventTypesController eventtypescontroller = new EventTypesController(context);

            //Act
            var result = await eventtypescontroller.Details(1);

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(9000)]
        public async void Details_ReturnsANotFoundResult(int? eventtyperId)
        {
            //Arrange 
            EventTypesController eventtypescontroller = new EventTypesController(context);

            //Act
            var result = await eventtypescontroller.Details(eventtyperId);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Create_ReturnsAViewResult()
        {
            //Arrange 
            EventTypesController eventtypescontroller = new EventTypesController(context);

            //Act
            var result = eventtypescontroller.Create();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void CreateAdd_RedirectToActionResult()
        {
            //Arrange 
            EventTypesController eventtypescontroller = new EventTypesController(context);

            //Act
            var result = await eventtypescontroller.Create(new EventTypes()
            {
                Id = 2,
                Type = "Marrige"

            });

            //Assert
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(9000)]
        public async void Edit_ReturnsANotFoundResult(int? eventtyperId)
        {
            //Arrange 
            EventTypesController eventtypescontroller = new EventTypesController(context);

            //Act
            var result = await eventtypescontroller.Edit(eventtyperId);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void Edit_ReturnsAViewResult()
        {
            //Arrange 
            EventTypesController eventtypescontroller = new EventTypesController(context);

            //Act
            var result = await eventtypescontroller.Edit(1);

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void Edit_Post_ReturnsANotFoundResult()
        {
            //Arrange 
            EventTypesController eventtypescontroller = new EventTypesController(context);

            //Act
            var result = await eventtypescontroller.Edit(2, new EventTypes());

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }


        [Fact]
        public async void Edit_Post_RedirectToActionResult()
        {
            //Arrange 
            EventTypesController eventtypescontroller = new EventTypesController(context);

            //Act
            var result = await eventtypescontroller.Edit(1, context.EventTypes.First());
            //Assert
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public async void Edit_Post_ReturnsANotFoundEventResult()
        {
            //Arrange 
            EventTypesController eventtypescontroller = new EventTypesController(context);
            //Act
            var result = await eventtypescontroller.Edit(2, new EventTypes()
            {
                Id = 2
            });
            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(9000)]
        public async void Delete_ReturnsANotFoundResult(int? eventtyperId)
        {
            //Arrange 
            EventTypesController eventtypescontroller = new EventTypesController(context);

            //Act
            var result = await eventtypescontroller.Delete(eventtyperId);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void Delete_Confirm_RedirectToActionResult()
        {
            //Arrange 
            EventTypesController eventtypescontroller = new EventTypesController(context);

            //Act
            var result = await eventtypescontroller.DeleteConfirmed(1);
            //Assert
            Assert.IsType<RedirectToActionResult>(result);
        }
    }
}
