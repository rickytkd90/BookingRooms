using System;
using BookingRooms.BL.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestEmployee
{
    [TestClass]
    public class EmployeeTest
    {
        private EmployeeManager manager = new EmployeeManager();

        [DataRow("Riccardo", "Grassi", "grassri2")] //grassri1 già presente sul db
        [DataRow("Dino", "Sauro", "saurodi1")]
        [DataRow("Ingra", "Naggi", "naggiin1")]
        [TestMethod]
        public void TestGenerateUsername(string name, string surname, string result)
        {
            Assert.AreEqual(result, manager.GenerateUsername(name, surname));
        }

        [DataRow("Riccardo", "Grassi", "riccardo.grassi1@reti.it")] //grassri1 già presente sul db
        [DataRow("Dino", "Sauro", "dino.sauro@reti.it")]
        [DataRow("Ingra", "Naggi", "ingra.naggi@reti.it")]
        [TestMethod]
        public void TestGenerateEmailAddress(string name, string surname, string result)
        {
            Assert.AreEqual(result, manager.GenerateEmailAddress(name, surname));
        }
    }
}
