using BookingRooms.BL.Managers;
using BookingRooms.BL.Model;
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
    [RoutePrefix("api/room")]
    public class RoomController : ApiController
    {
        private readonly IRoomManager _roomManager;

        public RoomController
        (
            IRoomManager roomManager
        )
        {
            _roomManager = roomManager;
        }

        [Route("get/{id:int}")]
        [HttpGet]
        public IHttpActionResult GetResource(int id)
        {
            var result = _roomManager.GetRoomById(id);

            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [Route("get/all")]
        [HttpGet]
        public IHttpActionResult GetResources()
        {
            var result = _roomManager.GetRooms();

            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        //POST
        [Route("insert")]
        [HttpPost]
        public void InsertNewResource(RoomDto room)
        {
            _roomManager.InsertRoom(room);
        }
    }
}
