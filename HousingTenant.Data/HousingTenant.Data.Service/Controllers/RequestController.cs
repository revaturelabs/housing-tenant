using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HousingTenant.Data.Service.Brokers;
using HousingTenant.Data.Service.Models;
using HousingTenant.Data.Service.Interfaces;
using HousingTenant.Data.Service.Factory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HousingTenant.Data.Service.Controllers
{
    [Route("api/[controller]")]
    public class RequestController : Controller
    {
        private static RequestBroker rb = new RequestBroker ();
        private static IBroker<RequestDTO> srb = new BrokerFactory<RequestDTO> ().Create ();

        // GET: api/values
        [HttpGet]
        public List<RequestDTO> Get()
        {
            return srb.GetAll ();
        }

        /*// GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST api/values
        [HttpPost]
        public bool Post([FromBody]RequestDTO value)
        {
            return srb.Create (value);
        }

        /*// PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }*/

       /* // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
