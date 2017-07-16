using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using HousingTenant.Business.Library.Brokers;
using Newtonsoft.Json;
using HousingTenant.Business.Library.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HousingTenant.Business.Service.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AddressController : Controller
    {
    // GET: api/values
    [HttpGet]
    public IEnumerable<string> Get()
    {
      return new string[] { "value1", "value2" };
    }

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

    [HttpGet]
        public async Task<string> GetAddress()
    {
      var client = new HttpClient();
      var response = await client.GetAsync("http://localhost:54529/api/address/get", HttpCompletionOption.ResponseContentRead);
      //response.Content.
      if (response.IsSuccessStatusCode)
      {
        var addressJson = response.Content.ReadAsStringAsync().Result;
        var myObject = JsonConvert.DeserializeObject<Address>(addressJson);
        AddressBroker ab = new AddressBroker();
        var libraryAddress = ab.GetAddress(myObject);

        var serializedString = JsonConvert.SerializeObject(libraryAddress);
        return serializedString;
      }
      return "nothing";
    }
  }
}
