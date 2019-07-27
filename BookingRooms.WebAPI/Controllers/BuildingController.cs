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
    [RoutePrefix("api/building")]
    public class BuildingController : ApiController
    {
        private readonly IBuildingManager _buildingManager;

        public BuildingController
        (
            IBuildingManager buildingManager
        )
        {
            _buildingManager = buildingManager;
        }

        [Route("get/{id:int}")]
        [HttpGet]
        public IHttpActionResult GetResource(int id)
        {
            var result = _buildingManager.GetBuildingById(id);

            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [Route("get/all")]
        [HttpGet]
        public IHttpActionResult GetResources()
        {
            var result = _buildingManager.GetBuildings();

            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        //POST
        [Route("insert")]
        [HttpPost]
        public void InsertNewResource(BuildingDto building)
        {
            _buildingManager.InsertBuilding(building);
        }

    }
}
