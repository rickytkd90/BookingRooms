using System;
using BookingRooms.BL.Managers;
using BookingRooms.WebAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.WebApiTest
{
    [TestClass]
    public class BuildingControllerTest
    {
        [TestMethod]
        public void IsControlllerDefined()
        {
            var manager = new BuildingManager();
            var controller = new BuildingController(manager);
            Assert.IsNotNull(controller);
        }
    }
}
