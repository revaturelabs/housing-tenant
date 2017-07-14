using HousingTenant.Data.Library;
using HousingTenant.Data.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousingTenant.Data.Service.Brokers
{
  public class AddressBroker
  {
    Address Get()
    {

      //Make Call to EF Context
      //object context = new object();
      //context = DBCOnnection();
      //use the databroker instead

      DataBroker db = new DataBroker();

      var myAddress = db.GetAddressByID(1);

      var myApiAddress = new Address();

      //Map it

      //Mapping by hand for now for the test

      //return it

      return myApiAddress;
    }
  }
}
