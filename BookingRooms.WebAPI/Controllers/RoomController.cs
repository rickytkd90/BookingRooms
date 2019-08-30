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
    [RoutePrefix("api/room")]
    public class RoomController : ApiController
    {

        #region .ctor

        private readonly IRoomManager _roomManager;

        public RoomController
        (
            IRoomManager roomManager
        )
        {
            _roomManager = roomManager;
        }

        #endregion

        /// <summary>
        /// Get Room by Id
        /// </summary>
        /// <param name="id">RoomId</param>
        /// <returns>Room item</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal Server Error</response>
        [Route("get/{id:int}")]
        [ResponseType(typeof(RoomDto))]
        [HttpGet]
        public IHttpActionResult GetRoom(int id)
        {
            var result = _roomManager.GetRoomById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Get Room list
        /// </summary>
        /// <returns>Room list</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal Server Error</response>
        [Route("get/all")]
        [ResponseType(typeof(IEnumerable<RoomDto>))]
        [HttpGet]
        public IHttpActionResult GetRooms()
        {
            return Ok(_roomManager.GetRooms());
        }

        /// <summary>
        /// Insert new Room
        /// </summary>
        /// <param name="room">Room item</param>
        /// <response code="200">OK</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal Server Error</response>
        [Route("add")]
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult InsertNewRoom(RoomDto room)
        {

            try
            {
                if (room != null && ModelState.IsValid)
                {
                    _roomManager.InsertRoom(room);
                    return Ok();
                }
                else
                    return BadRequest("I valori indicati per la nuova sala non sono validi");
            }
            catch(Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }
    }
}
