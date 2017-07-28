using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HousingTenant.Data.Library.AzModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HousingTenant.Data.Service.Controllers
{
    [Route("api/[controller]")]
    public class SupplyController : Controller
    {
        HousingTenantDBContext _Context;

        public SupplyController(HousingTenantDBContext context)
        {
            _Context = context;
        }

        // GET: api/values
        [HttpGet]
        public List<string> Get()
        {
            return (from s in _Context.SupplyType
                    select s.Supply).ToList();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            _Context.SupplyType.Add (new SupplyType
            {
                Supply = value
            });

            _Context.SaveChanges();
        }
    }
}
