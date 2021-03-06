﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace PoisonIvy.GatewayApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        //// GET: api/<controller>
        //[HttpGet]
        //public IActionResult Get()
        //{

        //    //https://www.c-sharpcorner.com/article/building-api-gateway-using-ocelot-in-asp-net-core-service-discovery-consul/
        //    //https://github.com/jasonmitchell/aspnet-core-consul/blob/master/docker-compose.yml
        //    //https://github.com/Skisas/ApiGateway-example
        //    //https://medium.com/@paulius.juozelskis/api-gateway-using-net-core-ocelot-and-consul-f0adea97f57
        //    //https://hub.docker.com/_/consul

        //    return Ok("Gateway API :)");
        //}

        // GET api/values  
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "value";
        }

        // GET api/values/demo1  
        [HttpGet("demo1")]
        public ActionResult<string> GetDemo1()
        {
            return "demo1";
        }

        // GET api/values/demo2  
        [HttpGet("demo2")]
        public ActionResult<string> GetDemo2()
        {
            return "demo2";
        }

        // GET api/values/demo3  
        [HttpGet("demo3")]
        public ActionResult<string> GetDemo3()
        {
            return "demo3";
        }

    }
}
