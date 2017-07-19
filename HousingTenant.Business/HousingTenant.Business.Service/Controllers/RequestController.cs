using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HousingTenant.Business.Service.Brokers;
using HousingTenant.Business.Library.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HousingTenant.Business.Service.Controllers
{
    [Route("api/[controller]")]
    public class RequestController : Controller
    {
        private static RequestBroker rb = new RequestBroker ();

        // GET: api/values
        [HttpGet]
        public IEnumerable<ARequest> Get()
        {
            return rb.Get ();
        }

        [HttpGet]
        public IEnumerable<ARequest> Get([FromBody] Apartment value)
        {
            return rb.Get (value);
        }

        // GET api/values/5
        /*[HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST api/values
        [HttpPost]
        public bool Post([FromBody]ARequest value)
        {
            return rb.Create (value);
        }

        // PUT api/values/5
        /*[HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }*/

        // DELETE api/values/5
        /*[HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
