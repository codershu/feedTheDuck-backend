using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using feedTheDuck.Models;
using feedTheDuck.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace feedTheDuck.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DuckController : Controller
    {
        private readonly IDuckService _duckService;

        public DuckController(IDuckService duckService)
        {
            _duckService = duckService;
        }

        [HttpGet]
        public string Get()
        {
            return "Hi! This is FeedTheDuck Backend Server for Freshworks Studio";
        }


        [HttpPost("AddRecord")]
        public ActionResult<Response<Guid>> AddRecord(DuckRecordRequest request)
        {
            return _duckService.AddRecord(request).Result;
        }
    }
}
