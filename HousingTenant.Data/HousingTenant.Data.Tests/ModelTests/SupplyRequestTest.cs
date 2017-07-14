using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using HousingTenant.Data.Library.DataModels;

namespace HousingTenant.Data.Tests.ModelTests
{
    [TestFixture]
    public class SupplyRequestTest
    {
        [Test]
        public void CreateSupplyRequest()
        {
            var test = new SupplyRequest();

            Assert.IsNotNull(test);

            Assert.IsTrue(test.supplies.Count == (int)Supplies.numSupplies);
        }
    }
}
