using HousingTenant.Business.Library;
using HousingTenant.Business.Library.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Tests.LibraryManagerTests
{
    [TestFixture]
    public class BusinessLibraryManagerTests
    {
        [Test]
        public void LibraryManagerPackApartmentTest()
        {
            var apartment = new Apartment { Address = new Address { }, Bathrooms = 2, Beds = 3 };
            var persons = new List<IPerson> { };
            var requests = new List<ARequest> { };
            var manager = new LibraryManager();

            var actual = manager.PackApartment(apartment, persons, requests);

            Assert.IsNotNull(actual);
        }
        
        [Test]
        public void LibraryManagerValidateApartmentPositiveTest()
        {
         var apartment = new Apartment { Address = new Address { }, Bathrooms = 2, Beds = 3 };

         var actual = apartment.IsValid();

         Assert.IsTrue(actual);
        }

        [Test]
        public void LibraryManagerValidateApartmentNegativeTest()
        {
            var apartment = new Apartment { Beds = 3, Bathrooms = 1 };

            var actual = apartment.IsValid();

            Assert.IsFalse(actual);
        }
        
        [Test]
        public void LibraryManagerValidateRequestPositiveTest()
        {
            var request = new ComplaintRequest { Accused = new Person { FirstName = "Paul", LastName = "Jones" }, Description = "Serious problems man!" };

            var actual = request.IsValid();

            Assert.IsTrue(actual);
        }

        [Test]
        public void LibraryManagerValidateRequestNegativeTest()
        {
            var request = new ComplaintRequest { Description = "Serious problems man!" };

            var actual = request.IsValid();

            Assert.IsFalse(actual);
        }
        
        [Test]
        public void LibraryManagerValidateTenantPositiveTest()
        {
            var tenant = new Person { FirstName = "Paul", LastName = "Jones", Address = new Address { } };

            var actual = tenant.IsValid();

            Assert.IsTrue(actual);
        }

        [Test]
        public void LibraryManagerValidateTenantNegativeTest()
        {
            var tenant = new Person { FirstName = "Paul", LastName = "Jones" };

            var actual = tenant.IsValid();

            Assert.IsFalse(actual);
        }
    }
}
