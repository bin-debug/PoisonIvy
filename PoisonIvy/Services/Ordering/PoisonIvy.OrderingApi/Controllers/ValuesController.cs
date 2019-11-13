using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PoisonIvy.OrderingApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Ordering API :)");
        }
    }
}
