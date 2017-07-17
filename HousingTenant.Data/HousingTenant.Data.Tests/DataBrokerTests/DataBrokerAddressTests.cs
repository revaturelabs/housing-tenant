using System;
using System.Collections.Generic;
using System.Text;
using HousingTenant.Data.Library;
using NUnit.Framework;
using HousingTenant.Data.Library.Models;

namespace HousingTenant.Data.Tests
{
  [TestFixture]
  public class DataBrokerAddressTests
  {
    [Test]
    public void GetAddressTest()
    {
      DataBroker broker = new DataBroker();
      Address test = broker.GetAddressByID(1);

      Assert.NotNull(test);
      Assert.NotNull(test.Address1);
      Assert.NotNull(test.City);
      Assert.NotNull(test.State);
      Assert.NotNull(test.Zip);

      Console.WriteLine(test.Address1 + test.City + test.State + test.Zip);
    }

    [Test]
    public void GetAddressesTest()
    {
      DataBroker bkr = new DataBroker();
      List<Address> test = bkr.GetAddresses();
      Assert.NotNull(test);

      Console.WriteLine(test[0].Address1);
    }
  }
}
