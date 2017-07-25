using System;
using System.Collections.Generic;
using System.Text;
using HousingTenant.Data.Library.DataModels;
using HousingTenant.Data.Library.AzModels;
using NUnit.Framework;

namespace HousingTenant.Data.Tests.Library.ModelTests
{
    [TestFixture]
    public class LibraryBrokerTest
    {
        private HousingTenantDBContext _Context;

        public LibraryBrokerTest(HousingTenantDBContext context)
        {
            _Context = context;
        }

        [Test]
        public void GetAllTest()
        {
            var lb = new LibraryBroker<Address> (_Context);
            var actual = lb.GetAll ();
            var expected = 0;

            Assert.IsTrue (actual.Count > expected);
        }
    }
}
