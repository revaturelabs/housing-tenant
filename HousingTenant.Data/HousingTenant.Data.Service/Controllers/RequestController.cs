using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HousingTenant.Data.Service.Models;
using HousingTenant.Data.Service.Interfaces;
using HousingTenant.Data.Service.Factory;
using HousingTenant.Data.Library.AzModels;


namespace HousingTenant.Data.Service.Controllers
{
    [Route("api/[controller]")]
    public class RequestController : Controller
    {
        private IBroker<RequestDAO> broker;

        public RequestController(HousingTenantDBContext context)
        {
            broker = new BrokerFactory<RequestDAO, Request> ().Create (context);
        }

        [HttpGet]
        public List<RequestDAO> Get()
        {
            return broker.GetAll();
        }

        [HttpPost]
        public bool Post([FromBody]RequestDAO value)
        {
            return true;
        }
    }
}
