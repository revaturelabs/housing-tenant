using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HousingTenant.Business.Library.Models;
using System.Net.Http;
using Newtonsoft.Json;
using HousingTenant.Business.Library;
using HousingTenant.Business.Service.Mappers;

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
        ServiceManager _ServiceManager = new ServiceManager();

        // GET: api/persons
        [HttpGet]
        public async Task<List<Person>> Get()
        {
            var persons = await client.GetAsync("person", HttpCompletionOption.ResponseContentRead);
            var personList = JsonConvert.DeserializeObject<List<Person>>(persons.Content.ReadAsStringAsync().Result);

            return personList;
        }

        // GET api/person/5
        [HttpGet("id")]
        public async Task<Person> Get([FromQuery]string id)
        {
            var uri = string.Format("{0}/{1}", "person", id);
            var person = await client.GetAsync(uri, HttpCompletionOption.ResponseContentRead);
            var deserializedPerson = JsonConvert.DeserializeObject<Person>(person.Content.ReadAsStringAsync().Result);

            return deserializedPerson;
        }
        
        // Get api/persons/address
        [HttpGet]
        [Route("address")]
        public async Task<List<Person>> Get([FromQuery]Address address)
        {
            var uri = string.Format("{0}/{1}", "person", address);
            var persons = await client.GetAsync(uri, HttpCompletionOption.ResponseContentRead);
            var personList = JsonConvert.DeserializeObject<List<Person>>(persons.Content.ReadAsStringAsync().Result);

            return personList;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Person person)
        {
         //var vperson = (Person)_LibraryManager.ValidateTenant(person);
         //client.PostAsJsonAsync("person", vperson);

         _ServiceManager.AddPerson(person);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Person person)
        {
            var vperson = _LibraryManager.ValidateTenant(person);
            client.PutAsJsonAsync("person", vperson);
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
