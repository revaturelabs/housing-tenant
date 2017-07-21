using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using HousingTenant.Data.Service.Models;

namespace HousingTenant.Data.Tests.Service
{
    [TestFixture]
    public class ServiceMapperTest
    {
        private ServiceMapper<object, object> sm = new ServiceMapper<object, object> ();

        [Test]
        public void MapToUTest()
        {
            Assert.IsFalse (true);
        }

        [Test]
        public void MapToTTest()
        {
            Assert.IsFalse (true);
        }
    }
}
}
