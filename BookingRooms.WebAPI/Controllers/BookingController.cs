﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BookingRooms.WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:44399", headers: "*", methods: "*")]
    [RoutePrefix("api/booking")]
    public class BookingController : ApiController
    {
    }
}