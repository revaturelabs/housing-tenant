using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HousingTenant.Business.Library.Models;
using HousingTenant.Business.Service.Models;
using System.Net.Http;
using HousingTenant.Business.Library;
using HousingTenant.Business.Service.Mappers;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects,
// visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HousingTenant.Business.Service.Controllers
{
   [Route("api/[controller]")]
   public class RequestController : Controller
   {
      HttpClient client = new HttpClient { BaseAddress = new Uri("https://housingtenantdata.azurewebsites.net/api/") };
      LibraryManager _LibraryManager = new LibraryManager();
      BusinessServiceMapper ServiceMapper = new BusinessServiceMapper();

      // GET: api/values
      [HttpGet]
      public async Task<List<RequestDTO>> Get()
      {
         var requests = await client.GetAsync("request", HttpCompletionOption.ResponseContentRead);
         var requestDtos = JsonConvert.DeserializeObject<List<RequestDTO>>(requests.Content.ReadAsStringAsync().Result);

         return requestDtos;
      }

      [HttpGet("{id}")]
      public async Task<RequestDTO> Get(string id)
      {
         var uri = string.Format("{0}/{1}", "request", id);
         var request = await client.GetAsync(uri, HttpCompletionOption.ResponseContentRead);
         var requestDto = JsonConvert.DeserializeObject<RequestDTO>(request.Content.ReadAsStringAsync().Result);

         return requestDto;
      }

      [HttpGet("{address}")]
      public async Task<List<RequestDTO>> Get([FromBody] Address address)
      {
         var uri = string.Format("{0}/{1}", "request", address);
         var requests = await client.GetAsync(uri, HttpCompletionOption.ResponseContentRead);
         var requestDtos = JsonConvert.DeserializeObject<List<RequestDTO>>(requests.Content.ReadAsStringAsync().Result);

         return requestDtos;
      }

      // POST api/values
      [HttpPost]
      public void Post([FromBody]RequestDTO request)
      {
         var vARequest = _LibraryManager.ValidateRequest(ServiceMapper.MapToARequest(request));
         if (vARequest != null)
         {
            client.PostAsJsonAsync("request", vARequest);
         }
      }

       // POST api/values
       [HttpPost("{ComplaintRequest}")]
       public void Post([FromBody]ComplaintRequest request)
       {
            var vARequest = _LibraryManager.ValidateRequest(request);
           if (vARequest != null)
           {
               client.PostAsJsonAsync("request", vARequest);
           }
      }

      // POST api/values
      [HttpPost("{MaintenaneRequest}")]
      public void Post([FromBody]MaintenanceRequest request)
      {
         var vARequest = _LibraryManager.ValidateRequest(request);
         if (vARequest != null)
         {
            client.PostAsJsonAsync("request", vARequest);
         }
      }

      // POST api/values
      [HttpPost("{MoveRequest}")]
      public void Post([FromBody]MoveRequest request)
      {
         var vARequest = _LibraryManager.ValidateRequest(request);
         if (vARequest != null)
         {
            client.PostAsJsonAsync("request", vARequest);
         }
      }

      // POST api/values
      [HttpPost("{SupplyRequest}")]
      public void Post([FromBody]SupplyRequest request)
      {
         var vARequest = _LibraryManager.ValidateRequest(request);
         if (vARequest != null)
         {
            client.PostAsJsonAsync("request", vARequest);
         }
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]RequestDTO request)
      {
         var vARequest = _LibraryManager.ValidateRequest(ServiceMapper.MapToARequest(request));
         if(vARequest != null)
         {
            client.PutAsJsonAsync("request", vARequest);
         }
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public void Delete(string id)
      {
         client.DeleteAsync(id);
      }
   }
}
