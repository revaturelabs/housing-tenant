using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HousingTenant.Business.Service.Brokers;
using HousingTenant.Business.Library.Models;
using System.Net.Http;
using Newtonsoft.Json;
using HousingTenant.Business.Library;

// For more information on enabling Web API for empty projects,
// visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HousingTenant.Business.Service.Controllers
{

    [Route("api/[controller]")]
    public class PersonController : Controller
   {
        HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:50411/api/") };
        LibraryManager _LibraryManager = new LibraryManager();

        private static PersonBroker pb = new PersonBroker ();

        // GET: api/persons
        [HttpGet]
        public async Task<List<Person>> Get()
        {
            // Ask Data API for all persons
            var persons = await client.GetAsync("person", HttpCompletionOption.ResponseContentRead);
            // Deserialize response into a person list -- may not need to do this but not sure, so
            var personList = JsonConvert.DeserializeObject<List<Person>>(persons.Content.ReadAsStringAsync().Result);

            return personList;
        }

        // GET api/person/5
        [HttpGet("{id}")]
        public async Task<Person> Get(int id)
        {
            var uri = string.Format("{0}/{1}", "person", id);
            var person = await client.GetAsync(uri, HttpCompletionOption.ResponseContentRead);
            var deserializedPerson = JsonConvert.DeserializeObject<Person>(person.Content.ReadAsStringAsync().Result);

            return deserializedPerson;
        }
        
        // Get api/persons/address
        [HttpGet("{address}")]
        public async Task<List<Person>> Get(Address address)
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
            var vperson = (Person)_LibraryManager.ValidateTenant(person);
            client.PostAsJsonAsync("person", vperson);
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
        public void Delete(Person person)
        {
            // FirstName << space >> LastName
            client.DeleteAsync(person.GetFullName());
        }
    }
}
