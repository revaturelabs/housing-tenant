using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using HousingTenant.Business.Library;
using Newtonsoft.Json;
using HousingTenant.Business.Service.Models;
using HousingTenant.Business.Library.Models;
using HousingTenant.Business.Service.Mappers;

// For more information on enabling Web API for empty projects,
// visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HousingTenant.Business.Service.Controllers
{
    [Route("api/[controller]")]
    public class ApartmentController : Controller
    {
        HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:50411/api/") };
        LibraryManager _LibraryManager = new LibraryManager();
        BusinessServiceMapper ServiceMapper = new BusinessServiceMapper();

        // GET: api/values
        [HttpGet]
        public async Task<List<Apartment>> Get()
        {
            // Make call to Data Service API for all Aparments
            var apartments = await client.GetAsync("apartment", HttpCompletionOption.ResponseContentRead);
            // Deserialize aRequest to an Apartment object
            var ApartmentList = JsonConvert.DeserializeObject<List<Apartment>>(apartments.Content.ReadAsStringAsync().Result);

            return ApartmentList;
        }

        [HttpGet("{address}")]
        public async Task<Apartment> Get(Address address)
        {
            // Make call to Data Service API for Aparment by Address
            var apartmentUrl = string.Format("apartment/{0}", address);
            var aRequest = await client.GetAsync(apartmentUrl, HttpCompletionOption.ResponseContentRead);
            // Deserialize aRequest to an Apartment object
            var emptyApartment = JsonConvert.DeserializeObject<Apartment>(aRequest.Content.ReadAsStringAsync().Result);

            // Make call to Data Service API for Person by Name
            var personUrl = string.Format("person/{0}", address);
            var pRequest = await client.GetAsync(personUrl, HttpCompletionOption.ResponseContentRead);
            // Deserialize pRequest to a Person object
            /// *** Cannot deserialize into an Interface Model/Mapping needed *** ///
            var persons = JsonConvert.DeserializeObject<List<Person>>(pRequest.Content.ReadAsStringAsync().Result);

            // Make call to Data Service API for Request by Address
            var requestUrl = string.Format("request/{0}", address);
            /// *** Cannot deserialize to an ABSTRACT class. Need model *** ///
            var rRequest = await client.GetAsync(requestUrl, HttpCompletionOption.ResponseContentRead);
            // Deserialize rRequest into Request objects
            var requests = JsonConvert.DeserializeObject<List<RequestDTO>>(rRequest.Content.ReadAsStringAsync().Result);

            // Now that I have all the pieces I need, ask library to package it for delivery
            var apartment = _LibraryManager.PackApartment(emptyApartment, ServiceMapper.MapToIPersonList(persons), ServiceMapper.MapToARequestList(requests));
            // Respond to Client
            return apartment as Apartment;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Apartment apartment)
        {
            var vApartment = (Apartment)_LibraryManager.ValidateApartment(apartment);
            client.PostAsJsonAsync("apartment", vApartment);
        }

        // PUT api/values/5
        [HttpPut("{address}")]
        public void Put(int id, [FromBody]Apartment apartment)
        {
            var vApartment = (Apartment)_LibraryManager.ValidateApartment(apartment);
            client.PutAsJsonAsync("apartment", vApartment);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            client.DeleteAsync("address");
        }
    }
}
