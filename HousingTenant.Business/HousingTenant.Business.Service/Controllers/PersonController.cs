using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HousingTenant.Business.Library.Models;
using System.Net.Http;
using Newtonsoft.Json;
using HousingTenant.Business.Library;
using HousingTenant.Business.Service.Mappers;
using HousingTenant.Business.Service.Models;

// For more information on enabling Web API for empty projects,
// visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HousingTenant.Business.Service.Controllers
{

    [Route("api/[controller]")]
    public class PersonController : Controller
   {
        HttpClient client = new HttpClient { BaseAddress = new Uri("https://housingtenantdata.azurewebsites.net/api/") };
        LibraryManager _LibraryManager = new LibraryManager();
        BusinessServiceMapper ServiceMapper = new BusinessServiceMapper();

        // GET: api/persons
        [HttpGet]
        public async Task<List<PersonDTO>> Get()
        {
         var persons = await client.GetAsync("person/getall", HttpCompletionOption.ResponseContentRead);
         var personList = JsonConvert.DeserializeObject<List<PersonDTO>>(persons.Content.ReadAsStringAsync().Result);

         return personList;
      }

        // GET api/person/5
        [HttpGet("id")]
        public async Task<PersonDTO> Get([FromQuery]string id)
        {
         var uri = string.Format("{0}/{1}", "person", id);
         var person = await client.GetAsync(uri, HttpCompletionOption.ResponseContentRead);
         var deserializedPerson = JsonConvert.DeserializeObject<PersonDTO>(person.Content.ReadAsStringAsync().Result);

         return deserializedPerson;
        }
        
        // Get api/person/email
        [HttpGet]
        [Route("email")]
        public async Task<PersonDTO> GetEmail([FromQuery]string email)
        {
            var uri = string.Format("person/getbyemail/{0}",email);
            var person = await client.GetAsync(uri, HttpCompletionOption.ResponseContentRead);
            var response = JsonConvert.DeserializeObject<PersonDTO>(person.Content.ReadAsStringAsync().Result);

            return response;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]PersonDTO person)
        {
            if (person != null)
            {
               var vperson = (Person)_LibraryManager.ValidateTenant(ServiceMapper.MapToIPerson(person));
               client.PostAsJsonAsync("person", vperson);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]PersonDTO person)
        {
            if (person != null)
            {
               var vperson = _LibraryManager.ValidateTenant(ServiceMapper.MapToIPerson(person));
               client.PutAsJsonAsync("person", vperson);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var deleteUri = string.Format("person/{0}", id);

            client.DeleteAsync(deleteUri);
        }
    }
}
