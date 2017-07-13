using System;
using System.Collections.Generic;
using System.Text;
using HousingTenant.Data.Library;
using HousingTenant.Data.Library.DataModels;
using NUnit.Framework;

namespace HousingTenant.Data.Tests
{
    [TestFixture]
    public class DataBrokerAddressTests
    {
        [Test]
        void GetAddressTest()
        {
            DataBroker broker = new DataBroker();
            Address test = broker.GetAddressByID(1);

            Assert.NotNull(test);
            Assert.NotNull(test.Address1);
            Assert.NotNull(test.City);
            Assert.NotNull(test.State);
            Assert.NotNull(test.Zip);
        }

    }
}
