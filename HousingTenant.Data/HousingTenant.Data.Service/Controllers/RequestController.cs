using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HousingTenant.Data.Service.Models;
using HousingTenant.Data.Service.Interfaces;
using HousingTenant.Data.Service.Factory;
using HousingTenant.Data.Library.Models;


namespace HousingTenant.Data.Service.Controllers
{
    [Route("api/[controller]")]
    public class RequestController : Controller
    {
        private static IBroker<RequestDAO> srb = new BrokerFactory<RequestDAO,Request> ().Create ();

        [HttpGet]
        public List<RequestDAO> Get()
        {
            var list = new List<RequestDAO> ();
            list.Add (new RequestDAO { Initiator = new PersonDAO { FirstName = "Jason", LastName = "Todd" } , DateSubmitted = DateTime.Now, Description = "Test" });
            return list;
        }

        [HttpPost]
        public bool Post([FromBody]RequestDAO value)
        {
            return srb.Create (value);
        }
    }
}
