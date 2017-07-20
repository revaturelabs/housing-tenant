using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using HousingTenant.Business.Library;
using Newtonsoft.Json;
using HousingTenant.Business.Service.Models;
using HousingTenant.Business.Library.Models;

// For more information on enabling Web API for empty projects,
// visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HousingTenant.Business.Service.Controllers
{
    [Route("api/[controller]")]
    public class ApartmentController : Controller
    {
        HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:50411/api/") };
        LibraryManager _LibraryManager = new LibraryManager();

        //public async Task<Apartment> GetApartment(Address address)
        [HttpGet("{address}")]
        public Apartment Get(Address address)
        {
            // Make call to Data Service API for Aparment by Address
            var apartmentUrl = string.Format("apartment/{0}", address);
            //var aRequest = await client.GetAsync(apartmentUrl, HttpCompletionOption.ResponseContentRead);
            // Deserialize aRequest to an Apartment object
            //var emptyApartment = JsonConvert.DeserializeObject<Apartment>(aRequest.Content.ReadAsStringAsync().Result);

            // Make call to Data Service API for Person by Name
            var personUrl = string.Format("person/{0}", address);
            //var pRequest = await client.GetAsync(personUrl, HttpCompletionOption.ResponseContentRead);
            // Deserialize pRequest to a Person object
            /// *** Cannot deserialize into an Interface Model/Mapping needed *** ///
            //var persons = JsonConvert.DeserializeObject<List<IPerson>>(pRequest.Content.ReadAsStringAsync().Result);

            // Make call to Data Service API for Request by Address
            var requestUrl = string.Format("request/{0}", address);
            /// *** Cannot deserialize to an ABSTRACT class. Need model *** ///
            //var rRequest = await client.GetAsync(requestUrl, HttpCompletionOption.ResponseContentRead);
            // Deserialize rRequest into Request objects
            //var requests = JsonConvert.DeserializeObject<List<ARequest>>(rRequest.Content.ReadAsStringAsync().Result);

            // ** TEMP TEST DATA TO TEST UI + API ** //
            var address1 = new Address { Address1 = "21 Person Drive", ApartmentNumber = "3C", City = "Reston", State = "VA", ZipCode = "12345" };
            var address2 = new Address { Address1 = "0 Such Street", ApartmentNumber = "D", City = "Herndon", State = "VA", ZipCode = "12345" };

            IPerson person1 = new Person { FirstName = "John", LastName = "Doe", Gender = GenderEnum.FEMALE, Address = address1 };
            var person2 = new Person { FirstName = "Pauline", LastName = "Doe", Gender = GenderEnum.FEMALE, Address = address1 };
            var person3 = new Person { FirstName = "Accuser", LastName = "Jones", Gender = GenderEnum.FEMALE, Address = address1 };
            var person4 = new Person { FirstName = "Donald", LastName = "Payne", Gender = GenderEnum.MALE, };
            
            var tApartment = new Apartment { Address = address1, Bathrooms = 2, Beds = 6 };

            var tPersons = new List<IPerson> { person1, person2, person3, person4 };
            
            var tRequests = new List<ARequest> {
               new ComplaintRequest {Initiator = person3, Accused = person1, Complaint = "I don't like his dress code", DateSubmitted = DateTime.Now, Status = StatusEnum.INWORK },
               new MaintenanceRequest { Initiator = person4, Description = "Toilet don't flush", DateSubmitted = DateTime.Now, Status = StatusEnum.PENDING, Urgent = true},
               new MoveRequest { Initiator = person2, RequestedApartmentAddress = address2,
                     Reason = "Can't stand my roommates", DateSubmitted = DateTime.Now, Status = StatusEnum.REJECTED, Urgent = false},
               new SupplyRequest {Initiator = person4,
                  RequestItems = new List<string> {"Toilet Paper", "Dishwashing Fluid", "Light Bulbs", "Trash bags"},
                  DateSubmitted = DateTime.Now, Status = StatusEnum.INWORK, Urgent = true}
            };

            var testApartment = _LibraryManager.PackApartment(tApartment, tPersons, tRequests);
            return testApartment as Apartment;
            // ** END TEMP DATA ** //

            // Now that I have all the pieces I need, ask library to package it for delivery
            //var apartment = _LibraryManager.PackApartment(emptyApartment, persons, requests);
            // Respond to Client
            //return apartment as Apartment;
        }

        // GET: api/values
        /*
        [HttpGet]
        public IEnumerable<string> Get()
        {
           return new string[] { "value1", "value2" };
        }*/

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
