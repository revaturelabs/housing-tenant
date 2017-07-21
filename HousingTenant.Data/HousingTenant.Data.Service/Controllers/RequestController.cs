using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HousingTenant.Data.Service.Models;
using HousingTenant.Data.Service.Interfaces;
using HousingTenant.Data.Service.Factory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HousingTenant.Data.Service.Controllers
{
    [Route("api/[controller]")]
    public class RequestController : Controller
    {
        private static IBroker<RequestDTO> srb = new BrokerFactory<RequestDTO> ().Create ();

        // GET: api/values
        [HttpGet]
        public List<RequestDTO> Get()
        {
            var list = new List<RequestDTO> ();
            list.Add (new RequestDTO { Initiator = new PersonDTO { FirstName = "Jason", LastName = "Todd" } , DateSubmitted = DateTime.Now, Description = "Test" });
            list.Add (srb.GetAll ()[0]);
            return list;
        }

        // POST api/values
        [HttpPost]
        public bool Post([FromBody]RequestDTO value)
        {
            return srb.Create (value);
        }
    }
}
