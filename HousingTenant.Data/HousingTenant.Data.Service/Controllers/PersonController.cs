using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HousingTenant.Data.Service.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HousingTenant.Data.Service.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        // GET: api/values
        [HttpGet]
        public List<PersonDAO> Get()
        {
            var list = new List<PersonDAO> ();
            list.Add (new PersonDAO { LastName = "Todd", FirstName = "Jason" });
            return list;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public List<PersonDAO> Get(string id)
        {
            var list = new List<PersonDAO> ();
            list.Add (new PersonDAO { LastName = "Todd", FirstName = "Jason" });
            list.Add (new PersonDAO { LastName = "Json", FirstName = "Fred" });
            var output = (from l in list where l.FirstName == id select l);
            return output.ToList();
        }

        // POST api/values
        [HttpPost]
        public bool Post([FromBody]PersonDAO value)
        {
            var outcome = false;

            if(value.FirstName != null)
            {
                outcome = true;
            }

            return outcome;
        }
    }
}
