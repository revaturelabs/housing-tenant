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
      ServiceManager _ServiceManager = new ServiceManager();

      // GET: api/values
      [HttpGet]
      public async Task<List<RequestDTO>> Get()
      {
         var requests = await client.GetAsync("request", HttpCompletionOption.ResponseContentRead);
         var requestDtos = JsonConvert.DeserializeObject<List<RequestDTO>>(requests.Content.ReadAsStringAsync().Result);

         return requestDtos;
         //return ServiceMapper.MapToRequestDTOList(_ServiceManager.GetRequests());
      }

      [Route("id")]
      public async Task<List<RequestDTO>> Get([FromQuery]string id)
      {
         //Collect Request by ApartmentId
         var uri = string.Format("{0}/{1}", "request", id);
         var request = await client.GetAsync(uri, HttpCompletionOption.ResponseContentRead);
         var requestDto = JsonConvert.DeserializeObject<List<RequestDTO>>(request.Content.ReadAsStringAsync().Result);

         return requestDto;
         //return ServiceMapper.MapToRequestDTOList(_ServiceManager.GetRequests(id));
      }

      [HttpGet]
      [Route("address")]
      public List<RequestDTO> Get([FromBody]Address address)
      //public async Task<List<RequestDTO>> Get([FromBody] Address address)
      {
         //if (address.IsValid())
         //{
         //    var uri = string.Format("{0}/{1}", "request", address);
         //    var requests = await client.GetAsync(uri, HttpCompletionOption.ResponseContentRead);
         //    var requestDtos = JsonConvert.DeserializeObject<List<RequestDTO>>(requests.Content.ReadAsStringAsync().Result);

         //    return requestDtos;
         //}
         //return new List<RequestDTO>();
         return ServiceMapper.MapToRequestDTOList(_ServiceManager.GetRequests(address));
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
         //_ServiceManager.AddRequest(ServiceMapper.MapToARequest(request));
      }

       // POST api/values
       [HttpPost("{ComplaintRequest}")]
       [Route("complaintrequest")]
       public void PostComplaintRequest([FromBody]RequestDTO request)
       {
           var vARequest = _LibraryManager.ValidateRequest(ServiceMapper.MapToARequest(request));
           if (vARequest != null)
           {
               client.PostAsJsonAsync("request", vARequest);
           }
      }

      // POST api/values
      [HttpPost("{MaintenaneRequest}")]
      [Route("maintenancerequest")]
      public void PostMaintenanceRequest([FromBody]RequestDTO request)
      {
         var vARequest = _LibraryManager.ValidateRequest(ServiceMapper.MapToARequest(request));
         if (vARequest != null)
         {
            client.PostAsJsonAsync("request", vARequest);
         }
      }

      // POST api/values
      [HttpPost("{MoveRequest}")]
      [Route("moverequest")]
      public void PostMoveRequest([FromBody]RequestDTO request)
      {
         var vARequest = _LibraryManager.ValidateRequest(ServiceMapper.MapToARequest(request));
         if (vARequest != null)
         {
            client.PostAsJsonAsync("request", vARequest);
         }
      }

      // POST api/values
      [HttpPost("{SupplyRequest}")]
      [Route("supplyrequest")]
      public void PostSupplyRequest([FromBody]RequestDTO request)
      {
         var vARequest = _LibraryManager.ValidateRequest(ServiceMapper.MapToARequest(request));
         if (vARequest != null)
         {
            client.PostAsJsonAsync("request", vARequest);
         }
      }

      // PUT api/values/5
      [HttpPut]
      public void Put(int id, [FromBody]RequestDTO request)
      {
         var vARequest = _LibraryManager.ValidateRequest(ServiceMapper.MapToARequest(request));
         if(vARequest != null)
         {
            client.PutAsJsonAsync("request", vARequest);
         }
      }

      // DELETE api/values/5
      [HttpDelete]
      public void Delete(string id)
      {
         client.DeleteAsync("request/" + id);
      }
   }
}
