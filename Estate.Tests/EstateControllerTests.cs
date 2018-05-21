using System;
using System.Collections.Generic;
using System.Web;
using Estate.Controllers;
using Estate.Data;
using Estate.Models;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using Microsoft.AspNetCore.Http;

namespace Estate.Tests
{
    public class EstateControllerTests
    {
        [Fact]
        public void GetDetails()
        {
            // Arrange
            var mockSet = new Mock<DbSet<Appartment>>();

            var data = new List<Appartment>
            {
                new Appartment { Id = 1 },
            }.AsQueryable();
            
            mockSet.As<IQueryable<Appartment>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Appartment>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Appartment>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Appartment>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(m => m.Appartments).Returns(mockSet.Object);
            var controller = new EstateController(mockContext.Object);

            // Act
            var result = controller.Details(1) as ViewResult;

            // Assert 
            var model = result.Model as Appartment;
            Assert.Equal(1, model.Id);
            
        }

        [Fact]
        public void TryManage()
        {
            var fakeHttpContext = new Mock<HttpContext>();
            var fakeIdentity = new GenericIdentity("User");
            var principal = new GenericPrincipal(fakeIdentity, null);

            fakeHttpContext.Setup(t => t.User).Returns(principal);

            var controllerContext = new Mock<ControllerContext>();

            controllerContext.Setup(t => t.HttpContext).Returns(fakeHttpContext.Object);

            var mockSet = new Mock<DbSet<Appartment>>();

            var data = new List<Appartment>
            {
                new Appartment { Id = 1 },
                new Appartment { Id = 2 },
            }.AsQueryable();

            mockSet.As<IQueryable<Appartment>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Appartment>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Appartment>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Appartment>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(m => m.Appartments).Returns(mockSet.Object);

            var controller = new EstateController(mockContext.Object);
            

            //Set your controller ControllerContext with fake context

            controller.ControllerContext = controllerContext.Object;
            
            // Act
            var result = controller.Manage() as ViewResult;

            // Assert 
            var model = result.Model as AppartmentsListModel;
            Assert.Equal(data.Count(), model.Appartments.Count());
        }

        [Fact]
        public void TryDelete()
        {
            // Arrange
            var mockSet = new Mock<DbSet<Appartment>>();

            var data = new List<Appartment>
            {
                new Appartment { Id = 1 },
            }.AsQueryable();

            mockSet.As<IQueryable<Appartment>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Appartment>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Appartment>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Appartment>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(m => m.Appartments).Returns(mockSet.Object);
            var controller = new EstateController(mockContext.Object);

            // Act
            var result = controller.Delete(1) as RedirectToActionResult;

            // Assert 
            Assert.Equal("Manage", result.ActionName);
        }
    }
}
