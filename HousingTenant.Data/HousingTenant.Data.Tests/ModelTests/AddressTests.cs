using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using HousingTenant.Data.Library.DataModels;

namespace HousingTenant.Data.Tests.ModelTests
{
    [TestFixture]
    public class AddressTests
    {
        [Test]
        public void CreateAddress()
        {
            var test = new Address();

            Assert.IsNotNull(test);
        }
    }
}
