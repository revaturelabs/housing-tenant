using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using HousingTenant.Data.Service.Factory;
using HousingTenant.Data.Service.Models;
using HousingTenant.Data.Service.Interfaces;

namespace HousingTenant.Data.Tests.Service
{
    [TestFixture]
    public class BrokerFactoryTest
    {
        [Test]
        public void GetBrokerTest()
        {
            var actual = new BrokerFactory<RequestDTO>().Create();

            Assert.IsNotNull (actual);
        }
    }
}
