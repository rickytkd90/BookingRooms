using System;
using BookingRooms.BL.Managers;
using BookingRooms.WebAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.WebApiTest
{
    [TestClass]
    public class EmployeeControllerTest
    {
        [TestMethod]
        public void IsControlllerDefined()
        {
            var manager = new EmployeeManager();
            var controller = new EmployeeController(manager);
            Assert.IsNotNull(controller);
        }
    }
}
