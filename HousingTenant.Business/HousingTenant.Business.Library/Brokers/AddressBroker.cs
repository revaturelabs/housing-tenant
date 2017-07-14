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
    public Address GetAddress(Address address)
    {
      return address;
    }

    public Address CreateAddress()
    {
      throw new NotImplementedException();
    }

    public Address UpdateAddress()
    {
      throw new NotImplementedException();
    }

    public Address DeleteAddress()
    {
      throw new NotImplementedException();
    }
  }
}
