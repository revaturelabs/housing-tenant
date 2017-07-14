using HousingTenant.Data.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousingTenant.Data.Service.Mapper;
using HousingTenant.Data.Library.Models;
using HousingTenant.Data.Service.Models;

namespace HousingTenant.Data.Service.Brokers
{
  public class AddressBroker
  {
    public AddressAPI Get()
    {

      //Make Call to EF Context
      //object context = new object();
      //context = DBCOnnection();
      //use the databroker instead

      DataBroker db = new DataBroker();

      var myAddress = db.GetAddressByID(1);

      var myApiAddress = new AddressAPI();

      //Map it

      Mapper1 map = new Mapper1();

      myApiAddress = map.AddressEntitytoAddressAPI<AddressAPI>(myAddress);

      return myApiAddress;
    }
  }
}
