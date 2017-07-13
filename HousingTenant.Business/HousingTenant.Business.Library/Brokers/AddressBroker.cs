using HousingTenant.Business.Library.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HousingTenant.Business.Library.Brokers
{
  public class AddressBroker
  {
    public async Task<Address> GetAddress()
    {
      var client = new HttpClient();

      var address = new Address();

      var response = await client.GetAsync("URI/address", HttpCompletionOption.ResponseContentRead);

      if (response.IsSuccessStatusCode)
      {
        address = JsonConvert.DeserializeObject<Address>(response.Content.ReadAsStringAsync().Result);
        return address;
      }
      return null;
    }
  }
}
