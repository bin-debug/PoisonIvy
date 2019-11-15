using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Couchbase.Core;
using Couchbase.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PoisonIvy.CatalogApi.Domain.Interfaces;
using PoisonIvy.CatalogApi.Domain.Models;

namespace PoisonIvy.CatalogApi.Controllers
{
    [Route("api/[controller]")]
    public class CatalogController : Controller
    {

        private readonly IRepository<CatalogItem> _repository;

        public CatalogController(IRepository<CatalogItem> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var results = await _repository.Get();
            if (results.Count > 0)
                return Ok(results);
            else
                return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CatalogItem catalogItem)
        {
            if (catalogItem == null)
                return BadRequest();
            else
            {
                var result = await _repository.Upsert(catalogItem);
                return Created("",result);
            }
        }

    }
}
