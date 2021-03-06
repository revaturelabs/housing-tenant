﻿using System;
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

      [Route("id")]
      public async Task<List<RequestDTO>> Get([FromQuery]string id)
      {
         //Collect Request by ApartmentId
         var uri = string.Format("{0}/{1}", "request", id);
         var request = await client.GetAsync(uri, HttpCompletionOption.ResponseContentRead);
         var requestDto = JsonConvert.DeserializeObject<List<RequestDTO>>(request.Content.ReadAsStringAsync().Result);

         return requestDto;
      }

      // POST api/values
      [HttpPost]
      public void Post([FromBody]RequestDTO request)
      {
         if (request != null)
         {
            if (request.Accused != null) {
               request.Type = "ComplaintRequest";
            }
            else if (request.RequestedApartmentAddress != null) {
               request.Type = "MoveRequest";
            }
            else if (request.RequestItems != null) {
               request.Type = "SupplyRequest";
            }
            else
               request.Type = "MaintenanceRequest";

            var vARequest = _LibraryManager.ValidateRequest(ServiceMapper.MapToARequest(request));
            if (vARequest != null)
            {
               client.PostAsJsonAsync("request", request);
            }
         }
      }

       // POST api/values
       [HttpPost("{ComplaintRequest}")]
       [Route("complaintrequest")]
       public void PostComplaintRequest([FromBody]RequestDTO request)
       {
           if (request != null)
           {
               request.Type = "ComplaintRequest";
               var vARequest = _LibraryManager.ValidateRequest(ServiceMapper.MapToARequest(request));
               if (vARequest != null)
               {
                  client.PostAsJsonAsync("request", request);
               }
           }
       }

      // POST api/values
      [HttpPost("{MaintenaneRequest}")]
      [Route("maintenancerequest")]
      public void PostMaintenanceRequest([FromBody]RequestDTO request)
      {
         if (request != null)
         {
            request.Type = "MaintenanceRequest";
            var vARequest = _LibraryManager.ValidateRequest(ServiceMapper.MapToARequest(request));
            if (vARequest != null)
            {
               client.PostAsJsonAsync("request", request);
            }
         }
      }

      // POST api/values
      [HttpPost("{MoveRequest}")]
      [Route("moverequest")]
      public void PostMoveRequest([FromBody]RequestDTO request)
      {
         if (request != null)
         {
            request.Type = "MoveRequest";
            var vARequest = _LibraryManager.ValidateRequest(ServiceMapper.MapToARequest(request));
            if (vARequest != null)
            {
               client.PostAsJsonAsync("request", request);
            }
         }
      }

      // POST api/values
      [HttpPost("{SupplyRequest}")]
      [Route("supplyrequest")]
      public void PostSupplyRequest([FromBody]RequestDTO request)
      {
         if (request != null)
         {
            request.Type = "SupplyRequest";
            var vARequest = _LibraryManager.ValidateRequest(ServiceMapper.MapToARequest(request));
            if (vARequest != null)
            {
               request.RequestItems = _LibraryManager.NormalizeRequestList(((SupplyRequest)vARequest).RequestItems);
               client.PostAsJsonAsync("request", request);
            }
         }
      }

      // PUT api/values/5
      [HttpPut]
      public void Put(int id, [FromBody]RequestDTO request)
      {
         if (request != null)
         {
            var vARequest = _LibraryManager.ValidateRequest(ServiceMapper.MapToARequest(request));
            if (vARequest != null)
            {
               client.PutAsJsonAsync("request", request);
            }
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
