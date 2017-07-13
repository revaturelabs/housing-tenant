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
      object context = new object();
      //context = DBCOnnection();

      var myAddress = new Address();


      //Map it

      //return it

      return myAddress;
    }
  }
}
