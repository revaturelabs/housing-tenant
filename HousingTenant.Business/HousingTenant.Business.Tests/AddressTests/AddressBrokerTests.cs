using HousingTenant.Business.Library.Brokers;
using HousingTenant.Business.Library.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Tests.AddressTests
{
  [TestFixture]
  public class AddressBrokerTests
  {
    [Test]
    public void GetAddress()
    {
      AddressBroker ab = new AddressBroker();

      var address = new Address();

      var test = ab.GetAddress(address);

      Assert.IsNotNull(test);
    }
  }
}
