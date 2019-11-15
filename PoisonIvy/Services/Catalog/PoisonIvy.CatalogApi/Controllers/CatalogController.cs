using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Couchbase.Core;
using Couchbase.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace PoisonIvy.CatalogApi.Controllers
{
    [Route("api/[controller]")]
    public class CatalogController : Controller
    {
        private readonly IBucket _bucket;
        public IConfiguration Configuration { get; }


        public CatalogController(IBucketProvider bucketProvider, IConfiguration configuration)
        {
            Configuration = configuration;
            _bucket = bucketProvider.GetBucket("catalog");
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
