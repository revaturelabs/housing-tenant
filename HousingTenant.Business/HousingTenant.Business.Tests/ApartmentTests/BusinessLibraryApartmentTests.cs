using HousingTenant.Business.Library.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Tests.ApartmentTests
{
    [TestFixture]
    public class BusinessLibraryApartmentTests
    {
        [Test]
        public void ApartmentCompareToPositiveTest()
        {
            var apartment1 = new Apartment()
            {
                Address = new Address { Address1 = "7 Dome Ln", ApartmentNumber = "2B", City = "Reston", State = "VA", ZipCode = "12345" },
                Bathrooms = 2,
                Beds = 6
            };

            var apartment2 = new Apartment()
            {
                Address = new Address { Address1 = "7 Dome Ln", ApartmentNumber = "2B", City = "Reston", State = "VA", ZipCode = "12345" },
                Bathrooms = 2,
                Beds = 6
            };

            Assert.IsTrue(apartment1.CompareTo(apartment2) == 0);
        }

        [Test]
        public void ApartmentCompareToNegativeTest()
        {
            var apartment1 = new Apartment()
            {
                Address = new Address { Address1 = "7 Dome Ln", ApartmentNumber = "2B", City = "Reston", State = "VA", ZipCode = "12345" },
                Bathrooms = 2,
                Beds = 6
            };

            var apartment2 = new Apartment()
            {
                Address = new Address { Address1 = "5 Dome Ln", ApartmentNumber = "2B", City = "Reston", State = "VA", ZipCode = "12345" },
                Bathrooms = 2,
                Beds = 6
            };

            Assert.IsFalse(apartment1.CompareTo(apartment2) < 0);
        }
        
        [Test]
        public void ApartmentToStringTest()
        {
            var apartment1 = new Apartment()
            {
                Address = new Address { Address1 = "7 Dome Ln", ApartmentNumber = "2B", City = "Reston", State = "VA", ZipCode = "12345" },
                Bathrooms = 2,
                Beds = 6
            };

            Assert.IsNotNull(apartment1.ToString());
        }

        [Test]
        public void ApartmentAddRequestTest()
        {
            var apartment1 = new Apartment()
            {
               Address = new Address { Address1 = "7 Dome Ln", ApartmentNumber = "2B", City = "Reston", State = "VA", ZipCode = "12345" },
               Bathrooms = 2,
               Beds = 6
            };

            apartment1.AddRequest(new ComplaintRequest());

            Assert.IsNotEmpty(apartment1.Requests);
        }

        [Test]
        public void ApartmentAddTenentTest()
        {
            var apartment1 = new Apartment()
            {
               Address = new Address { Address1 = "7 Dome Ln", ApartmentNumber = "2B", City = "Reston", State = "VA", ZipCode = "12345" },
               Bathrooms = 2,
               Beds = 6
            };

            apartment1.AddTenant(new Person());

            Assert.IsNotEmpty(apartment1.Persons);
        }


        [Test]
        public void ApartmentOpenRequestTest()
        {
            var apartment1 = new Apartment()
            {
               Address = new Address { Address1 = "7 Dome Ln", ApartmentNumber = "2B", City = "Reston", State = "VA", ZipCode = "12345" },
               Bathrooms = 2,
               Beds = 6
            };

            apartment1.AddRequest(new ComplaintRequest());

            Assert.IsNotEmpty(apartment1.OpenRequests());
        }
   }
}
