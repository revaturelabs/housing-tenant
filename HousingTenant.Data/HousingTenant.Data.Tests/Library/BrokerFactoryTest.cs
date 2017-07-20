using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using HousingTenant.Data.Library.Factory;

namespace HousingTenant.Data.Tests.Library
{
    [TestFixture]
    public class BrokerFactoryTest
    {
        [Test]
        public void GetBrokerTest()
        {
            var actual = new BrokerFactory<Object> ().Create ();

            Assert.IsNotNull (actual);
        }
    }
}
