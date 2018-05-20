using System;
using Estate.Data;
using Estate.Controllers;
using Moq;
using Estate.Models;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Estate.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexReturnsAListOfAppartments()
        {
            //Arrange
            var mock = new Mock<ApplicationDbContext>();
            mock.Setup(context => context.Appartments.ToList()).Returns(GetTestAppartments());
            var controller = new HomeController(mock.Object);

            //Act
            var result = controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Appartment>>(viewResult.Model);
            Assert.Equal(GetTestAppartments().Count, model.Count());
        }

        private List<Appartment> GetTestAppartments()
        {
            var appartments = new List<Appartment>
            {
                new Appartment { Id=1, Adress="Luchakivska", Price= 10000, Images="aasdf", UserEmail="qwwwwww"},
                new Appartment { Id=2, Adress="Luch", Price= 20000, Images="avbnm", UserEmail="qvvvvv"},
                new Appartment { Id=3, Adress="Kivska", Price= 30000, Images="poiuy", UserEmail="qoooooo"},
                new Appartment { Id=4, Adress="Lucka", Price= 40000, Images="tgbnhh", UserEmail="qqqqqqq"},
            };
            return appartments;
        }
    }


}
