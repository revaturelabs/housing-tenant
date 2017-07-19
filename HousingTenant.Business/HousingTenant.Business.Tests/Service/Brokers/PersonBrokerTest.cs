using System;
using System.Collections.Generic;
using System.Text;
using HousingTenant.Business.Service.Brokers;
using HousingTenant.Business.Library.Models;
using NUnit.Framework;

namespace HousingTenant.Business.Tests.Service.Brokers
{
    [TestFixture]
    public class PersonBrokerTest
    {
        private static PersonBroker pb = new PersonBroker ();

        [Test]
        public void GetAllTest()
        {
            var actual = new List<Person> ();
            var expected = 0;

            actual = pb.Get ();

            Assert.IsTrue (actual.Count > expected);
        }
    }
}
