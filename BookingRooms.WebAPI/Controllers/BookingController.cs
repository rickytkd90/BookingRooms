using BookingRooms.BL.Managers;
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
    [RoutePrefix("api/booking")]
    public class BookingController : ApiController
    {
        #region .ctor

        private readonly IBookingManager _bookingManager;

        public BookingController
        (
            IBookingManager bookingManager
        )
        {
            _bookingManager = bookingManager;
        }

        #endregion

        /// <summary>
        /// Get Booking by Id
        /// </summary>
        /// <param name="id">BookingId</param>
        /// <returns>Booking item</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal Server Error</response>
        [Route("get/{id:int}")]
        [ResponseType(typeof(BookingDto))]
        [HttpGet]
        public IHttpActionResult GetBooking(int id)
        {
            var result = _bookingManager.GetBookingById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Insert new Booking
        /// </summary>
        /// <param name="booking">Booking item</param>
        /// <response code="200">OK</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal Server Error</response>
        [Route("add")]
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult InsertNewBooking(BookingDto booking)
        {
            try
            {
                if (booking != null && ModelState.IsValid)
                {
                    _bookingManager.InsertBooking(booking);
                    return Ok();
                }
                else
                    return BadRequest("I valori indicati per la nuova prenotazione non sono validi");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }               
        }

        /// <summary>
        /// Get Booking list
        /// </summary>
        /// <returns>Booking list</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal Server Error</response>
        [Route("get/all")]
        [ResponseType(typeof(IEnumerable<BookingDto>))]
        [HttpGet]
        public IHttpActionResult GetBookings()
        {
            return Ok(_bookingManager.GetBookings());
        }

        /// <summary>
        /// Delete Booking
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">OK</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal Server Error</response>
        [Route("delete/{id:int}")]
        [ResponseType(typeof(void))]
        [HttpDelete]
        public IHttpActionResult DeleteBooking(int id)
        {
            try
            {
                _bookingManager.DeleteBooking(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
