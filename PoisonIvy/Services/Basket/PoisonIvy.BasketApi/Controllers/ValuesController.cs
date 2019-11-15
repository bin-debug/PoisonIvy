using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PoisonIvy.BasketApi.Domain.Commands;
using PoisonIvy.BasketApi.Domain.Models;
using PoisonIvy.Domain.Core.EventBus;

namespace PoisonIvy.BasketApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        private readonly IEventBus _bus;

        public ValuesController(IEventBus bus)
        {
            _bus = bus;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Basket API :)");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CatalogItem catalogItem)
        {
            if (catalogItem == null)
                return BadRequest();
            else
            {
                var createCatalogItemCommand = new CreateCatalogItemCommand(
                     name:catalogItem.Name,
                     price:catalogItem.Price,
                     qty:catalogItem.Qty
                    );

                await _bus.Send(createCatalogItemCommand);

                return Ok();
            }
        }
    }
}
