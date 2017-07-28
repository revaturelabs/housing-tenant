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
        HttpClient client = new HttpClient { BaseAddress = new Uri("https://housingtenantdata.azurewebsites.net/api/") };
        LibraryManager _LibraryManager = new LibraryManager();
        BusinessServiceMapper ServiceMapper = new BusinessServiceMapper();

      // GET: api/values
        [HttpGet]
        public async Task<List<ApartmentDTO>> Get()
        {
            var apartments = await client.GetAsync("apartment", HttpCompletionOption.ResponseContentRead);
            var ApartmentList = JsonConvert.DeserializeObject<List<ApartmentDTO>>(apartments.Content.ReadAsStringAsync().Result);

            return ApartmentList;
        }
        
        [Route("id")]
        public async Task<ApartmentDTO> Get([FromQuery]string id)
        {
            var uri = string.Format("apartment/{0}", id);
            var aRequest = await client.GetAsync(uri, HttpCompletionOption.ResponseContentRead);
            var emptyApartment = JsonConvert.DeserializeObject<ApartmentDTO>(aRequest.Content.ReadAsStringAsync().Result);

            var personUrl = string.Format("person/getbyapartment/{0}",id);
            var pRequest = await client.GetAsync(personUrl, HttpCompletionOption.ResponseContentRead);
            var persons = JsonConvert.DeserializeObject<List<PersonDTO>>(pRequest.Content.ReadAsStringAsync().Result);

            var requestUrl = string.Format("request/{0}",id);
            var rRequest = await client.GetAsync(requestUrl, HttpCompletionOption.ResponseContentRead);
            var requests = JsonConvert.DeserializeObject<List<RequestDTO>>(rRequest.Content.ReadAsStringAsync().Result);

            var apartment = _LibraryManager.PackApartment(ServiceMapper.MapToIApartment(emptyApartment), ServiceMapper.MapToIPersonList(persons), ServiceMapper.MapToARequestList(requests));

            return ServiceMapper.MapToApartmentDTO((Apartment)apartment);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]ApartmentDTO apartment)
        {
            var vApartment = (Apartment)_LibraryManager.ValidateApartment(ServiceMapper.MapToIApartment(apartment));
            client.PostAsJsonAsync("apartment", vApartment);
        }

        // PUT api/values/5
        [HttpPut("{address}")]
        public void Put(int id, [FromBody]ApartmentDTO apartment)
        {
            var vApartment = (Apartment)_LibraryManager.ValidateApartment(ServiceMapper.MapToIApartment(apartment));
            client.PutAsJsonAsync("apartment", vApartment);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var deleteUri = string.Format("apartment/{0}", id);

            client.DeleteAsync(deleteUri);
        }
    }
}
