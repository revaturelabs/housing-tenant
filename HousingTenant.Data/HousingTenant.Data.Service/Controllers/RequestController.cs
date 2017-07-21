using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HousingTenant.Data.Service.Models;
using HousingTenant.Data.Service.Interfaces;
using HousingTenant.Data.Service.Factory;


namespace HousingTenant.Data.Service.Controllers
{
    [Route("api/[controller]")]
    public class RequestController : Controller
    {
        private static IBroker<RequestDTO> srb = new BrokerFactory<RequestDTO> ().Create ();

        [HttpGet]
        public List<RequestDTO> Get()
        {
            var list = new List<RequestDTO> ();
            list.Add (new RequestDTO { Initiator = new PersonDTO { FirstName = "Jason", LastName = "Todd" } , DateSubmitted = DateTime.Now, Description = "Test" });
            list.Add (srb.GetAll ()[0]);
            return list;
        }

        [HttpPost]
        public bool Post([FromBody]RequestDTO value)
        {
            return srb.Create (value);
        }
    }
}
