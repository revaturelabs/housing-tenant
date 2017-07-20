using System;
using System.Collections.Generic;
using System.Text;
using HousingTenant.Data.Library.DataModels;
using NUnit.Framework;

namespace HousingTenant.Data.Tests.Library.ModelTests
{
    [TestFixture]
    public class LibraryBrokerTest
    {
        [Test]
        public void GetAllTest()
        {
            var lb = new LibraryBroker<Object> ();
            var actual = lb.GetAll ();
            var expected = 0;

            Assert.IsTrue (actual.Count > expected);
        }
    }
}
