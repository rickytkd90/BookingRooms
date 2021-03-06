﻿using BookingRooms.BL.Managers;
using BookingRooms.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace BookingRooms.WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:44399", headers: "*", methods: "*")]
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {

        #region .ctor

        private readonly IEmployeeManager _employeeManager;

        public EmployeeController
        (
            IEmployeeManager employeeManager
        )
        {
            _employeeManager = employeeManager;
        }

        #endregion

        /// <summary>
        /// Get Employee by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Employee item</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal Server Error</response>
        [Route("get/{id:int}")]
        [ResponseType(typeof(EmployeeDto))]
        [HttpGet]
        public IHttpActionResult GetEmployee(int id)
        {
            var result = _employeeManager.GetEmployeeById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Get Employee list
        /// </summary>
        /// <returns>Employee list</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal Server Error</response>
        [Route("get/all")]
        [ResponseType(typeof(IEnumerable<EmployeeDto>))]
        [HttpGet]
        public IHttpActionResult GetResources()
        {
            return Ok(_employeeManager.GetEmployees());
        }

        /// <summary>
        /// Insert new Employee
        /// </summary>
        /// <response code="200">OK</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal Server Error</response>
        [Route("add")]
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult InsertNewResource(EmployeeDto employee)
        {
            try
            {
                if (employee != null && ModelState.IsValid)
                {
                    _employeeManager.InsertEmployee(employee);
                    return Ok();
                }
                else
                    return BadRequest("I valori indicati per la nuova risorsa non sono validi");
            }
            catch(Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }
    }
}
