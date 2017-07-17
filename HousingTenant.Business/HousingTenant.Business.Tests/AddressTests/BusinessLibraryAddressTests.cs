using HousingTenant.Business.Library.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Tests.AddressTests
{
    [TestFixture]
    public class BusinessLibraryAddressTests
    {
        [Test]
        public void AddressEqualsPostiveTest()
        {
            var address1 = new Address
            {
                Address1 = "21 Fortress Lane",
                ApartmentNumber = "45C",
                City = "Reston",
                State = "VA",
                ZipCode = "12345"
            };

            var address2 = new Address
            {
                Address1 = "21 Fortress Lane",
                ApartmentNumber = "45C",
                City = "Reston",
                State = "VA",
                ZipCode = "12345"
            };

            Assert.IsTrue(address1.Equals(address2));
        }

        [Test]
        public void AddressEqualsNegativeTest()
        {
            var address1 = new Address
            {
                Address1 = "21 Fortress Lane",
                ApartmentNumber = "45C",
                City = "Reston",
                State = "VA",
                ZipCode = "12345"
            };

            var address2 = new Address
            {
                Address1 = "21 Fortress Lane",
                ApartmentNumber = "45A",
                City = "Reston",
                State = "VA",
                ZipCode = "12345"
            };

            Assert.IsFalse(address1.Equals(address2));
        }
        
        [Test]
        public void AddressGetHashCodeTest()
        {
            var address1 = new Address
            {
                Address1 = "21 Fortress Lane",
                ApartmentNumber = "45C",
                City = "Reston",
                State = "VA",
                ZipCode = "12345"
            };
            var actual = address1.GetHashCode();

            Assert.IsTrue(actual > 0);
        }
        
        [Test]
        public void AddressToStringTest()
        {
            var address1 = new Address
            {
                Address1 = "21 Fortress Lane",
                ApartmentNumber = "45C",
                City = "Reston",
                State = "VA",
                ZipCode = "12345"
            };
            var actual = address1.ToString();

            Assert.IsTrue(actual != null && actual.Length > 0);
        }
    }
}
