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
    [RoutePrefix("api/building")]
    public class BuildingController : ApiController
    {

        #region .ctor

        private readonly IBuildingManager _buildingManager;

        public BuildingController
        (
            IBuildingManager buildingManager
        )
        {
            _buildingManager = buildingManager;
        }

        #endregion

        /// <summary>
        /// Get Building by Id
        /// </summary>
        /// <param name="id">BuildingId</param>
        /// <returns>Buildng item</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal Server Error</response>
        [Route("get/{id:int}")]
        [ResponseType(typeof(BuildingDto))]
        [HttpGet]
        public IHttpActionResult GetBuilding(int id)
        {
            var result = _buildingManager.GetBuildingById(id);

            if(result==null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Get Buildings list
        /// </summary>
        /// <returns>Building list</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal Server Error</response>
        [Route("get/all")]
        [ResponseType(typeof(IEnumerable<BuildingDto>))]
        [HttpGet]
        public IHttpActionResult GetBuildings()
        {
            return Ok(_buildingManager.GetBuildings());
        }

        /// <summary>
        /// Insert new Building
        /// </summary>
        /// <param name="building">Building item</param>
        /// <response code="200">OK</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal Server Error</response>
        [Route("add")]
        [ResponseType(typeof(void))]
        [HttpPost]
        public void InsertNewBuilding(BuildingDto building)
        {
            _buildingManager.InsertBuilding(building);
        }

    }
}
