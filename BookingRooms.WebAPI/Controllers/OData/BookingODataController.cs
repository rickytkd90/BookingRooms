using BookingRooms.BL.Managers;
using BookingRooms.BL.Model;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace BookingRooms.WebAPI.Controllers.OData
{
    [EnableCors(origins: "http://localhost:44399", headers: "*", methods: "*")]
    [RoutePrefix("OData")]
    public class BookingODataController : ODataController
    {

        #region .ctor

        private readonly IBookingManager _bookingManager;

        public BookingODataController(IBookingManager bookingManager)
        {
            _bookingManager = bookingManager;
        }

        #endregion

        /// <summary>
        /// Get Bookings list
        /// </summary>
        /// <returns>Booking list</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal Server Error</response>
        [Route("bookings/list")]
        [ResponseType(typeof(IEnumerable<BookingDto>))]
        [HttpGet]
        public IHttpActionResult GetBookings(ODataQueryOptions<BookingDto> queryOption)
        {
            var result = queryOption.ApplyTo(_bookingManager.GetBookings().AsQueryable());
            return Ok(result);
        }
    }
}
