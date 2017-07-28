using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HousingTenant.Data.Library.AzModels;

namespace HousingTenant.Data.Service.Controllers
{
    [Route("api/[controller]")]
    public class SupplyController : Controller
    {
        /// <summary>
        /// private field containing the DBContext of the database being used
        /// </summary>
        HousingTenantDBContext _Context;

        /// <summary>
        /// Updates _Context to represent the current state of the database being used.
        /// </summary>
        /// <param name="context"></param>
        public SupplyController(HousingTenantDBContext context)
        {
            _Context = context;
        }

        /// <summary>
        /// Returns a list of supplies one can request for.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<string> Get()
        {
            return (from s in _Context.SupplyType
                    select s.Supply).ToList();
        }

        /// <summary>
        /// Add a new type of supply to the database.
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public bool Post([FromBody]string value)
        {
            _Context.SupplyType.Add (new SupplyType
            {
                Supply = value
            });

            return _Context.SaveChanges() > 0;
        }
    }
}
