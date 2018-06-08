using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MockProject3.Api.Controllers;
using Moq;
using MockProject3.DA;
using MockProject3.DA.Models;
using Microsoft.AspNetCore.Mvc;
using MockProject3.DA.Repos;
using Microsoft.EntityFrameworkCore;

namespace MockProject3.Test.Mocking
{
    public class ForecastControllerTests
    {
        private ForecastController controller;

        public ForecastControllerTests()
        {
            var moqUserRepo = new Mock<IRepo<User>>();
            var moqRoomRepo = new Mock<IRepo<Room>>();

            moqUserRepo.Setup(x => x.Get()).Returns(new List<User>());
            moqUserRepo.Setup(x => x.GetBetweenDates(It.IsAny<DateTime>(),It.IsAny<DateTime>())).Returns(new List<User>());
            moqUserRepo.Setup(x => x.GetBetweenDatesAtLocation(It.IsAny<DateTime>(), It.IsAny<DateTime>(),It.IsAny<string>())).Returns(new List<User>());
            moqUserRepo.Setup(x => x.GetByDate(It.IsAny<DateTime>())).Returns(new List<User>());
            moqUserRepo.Setup(x => x.GetLocations()).Returns(new List<string>());

            moqRoomRepo.Setup(x => x.Get()).Returns(new List<Room>());
            moqRoomRepo.Setup(x => x.GetBetweenDates(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(new List<Room>());
            moqRoomRepo.Setup(x => x.GetBetweenDatesAtLocation(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<string>())).Returns(new List<Room>());
            moqRoomRepo.Setup(x => x.GetByDate(It.IsAny<DateTime>())).Returns(new List<Room>());
            moqRoomRepo.Setup(x => x.GetLocations()).Returns(new List<string>());

            controller = new ForecastController(moqUserRepo.Object,moqRoomRepo.Object);
        }

        [Fact]
        public void Get_ValidModel_ReturnsOk()
        {
            var result = controller.Get();

            Assert.IsType<OkObjectResult>(result);
        }


    }
}
