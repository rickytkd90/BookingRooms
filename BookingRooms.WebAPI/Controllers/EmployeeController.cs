using BookingRooms.BL.Managers;
using BookingRooms.BL.Model;
using BookingRooms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BookingRooms.WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:44399", headers: "*", methods: "*")]
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeManager _employeeManager;

        public EmployeeController
        (
            IEmployeeManager employeeManager
        )
        {
            _employeeManager = employeeManager;
        }

        [Route("get/{id:int}")]
        [HttpGet]
        public IHttpActionResult GetResource(int id)
        {
            var result = _employeeManager.GetEmployeeById(id);

            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [Route("get/all")]
        [HttpGet]
        public IHttpActionResult GetResources()
        {
            var result = _employeeManager.GetEmployees();

            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        //POST
        [Route("insert")]
        [HttpPost]
        public void InsertNewResource(EmployeeDto employee)
        {
            _employeeManager.InsertEmployee(employee);
        }
    }
}
