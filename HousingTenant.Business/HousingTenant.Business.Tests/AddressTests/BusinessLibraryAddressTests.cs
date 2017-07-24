using HousingTenant.Business.Library.Models;
using NUnit.Framework;

namespace HousingTenant.Business.Tests.AddressTests
{
    [TestFixture]
    public class BusinessLibraryAddressTests
    {
        [Test]
        public void AddressCompareToPostiveTest()
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

            Assert.IsTrue(address1.CompareTo(address2) == 0);
        }

        [Test]
        public void AddressCompareToNegativeTest()
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

            Assert.IsFalse(address1.CompareTo(address2) < 0);
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
