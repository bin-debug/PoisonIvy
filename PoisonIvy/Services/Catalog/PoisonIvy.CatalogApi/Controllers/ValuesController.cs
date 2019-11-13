using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PoisonIvy.CatalogApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Catalog API :)");
        }
    }
}
