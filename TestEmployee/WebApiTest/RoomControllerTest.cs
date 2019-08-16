using System;
using BookingRooms.BL.Managers;
using BookingRooms.WebAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.WebApiTest
{
    [TestClass]
    public class RoomControllerTest
    {
        [TestMethod]
        public void IsControlllerDefined()
        {
            var manager = new RoomManager();
            var controller = new RoomController(manager);
            Assert.IsNotNull(controller);
        }
    }
}
