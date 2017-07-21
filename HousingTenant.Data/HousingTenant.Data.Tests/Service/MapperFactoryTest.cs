using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using HousingTenant.Data.Service.Factory;

namespace HousingTenant.Data.Tests.Service
{
    [TestFixture]
    public class MapperFactoryTest
    {
        [Test]
        public void GetMapperTest()
        {
            var mt = new MapperFactory<Object, Object> ().Create();

            Assert.IsNotNull (mt);
        }
    }
}
