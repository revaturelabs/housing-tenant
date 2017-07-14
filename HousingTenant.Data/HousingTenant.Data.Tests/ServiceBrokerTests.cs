using HousingTenant.Data.Library.Models;
using HousingTenant.Data.Service.Brokers;
using HousingTenant.Data.Service.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Data.Tests
{
    [TestFixture]
    class ServiceBrokerTests
    {

    [Test]
     public void AddressBrokerTest()
    {
      AddressBroker ab = new AddressBroker();
      AddressAPI testAddress = ab.Get();

      Assert.NotNull(testAddress.Address1);
      Assert.NotNull(testAddress.Address2);
      Assert.NotNull(testAddress.City);
      Assert.NotNull(testAddress.State);
      Assert.NotNull(testAddress.Zip);

    }


    }
}
