using System;
using BookingRooms.BL.Managers;
using BookingRooms.WebAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.WebApiTest
{
    [TestClass]
    public class BookingControllerTest
    {
        [TestMethod]
        public void IsControlllerDefined()
        {
            var manager = new BookingManager();
            var controller = new BookingController(manager);
            Assert.IsNotNull(controller);
        }
    }
}
