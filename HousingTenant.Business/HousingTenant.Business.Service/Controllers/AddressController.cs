﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HousingTenant.Business.Service.Controllers
{
    [Route("api/[controller]")]
    public class AddressController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        
    [HttpGet]
        public async Task<string> GetAddress()
    {
      var client = new HttpClient();
      var response = await client.GetAsync("http://localhost:52639/api/read/getpizzatoppings", HttpCompletionOption.ResponseContentRead);
      //response.Content.
      if (response.IsSuccessStatusCode)
      {
        var z = response.Content.ReadAsStringAsync().Result;
        return z;
      }
      return "nothing";
    }
    }
}
