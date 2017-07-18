using HousingTenant.Business.Library.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Tests.RequestTests
{
    [TestFixture]
    class BusinessLibraryMaintenanceRequestTests
    {
        [Test]
        public void MaintenanceRequestEqualsPositiveTest()
        {
            var request1 = new MaintenanceRequest
            {
                Initiator = new Person { FirstName = "Jane", LastName = "Doe",
                   Address = new Address { Address1 = "7 Joe Ln", ApartmentNumber = "2N", City = "Reston", State = "VA", ZipCode = "12345" } },
                Description = "Dishwasher does not work",
                DateSubmitted = DateTime.Now,
                Status = StatusEnum.PENDING
            };

            var request2 = new MaintenanceRequest
            {
               Initiator = new Person { FirstName = "Jane", LastName = "Doe",
                  Address = new Address { Address1 = "7 Joe Ln", ApartmentNumber = "2N", City = "Reston", State = "VA", ZipCode = "12345" } },
               Description = "Dishwasher does not work",
               DateSubmitted = DateTime.Now,
               Status = StatusEnum.PENDING
            };

            Assert.IsTrue(request1.Equals(request2));
        }

        [Test]
        public void MaintenanceRequestEqualsNegativeTest()
        {
            var request1 = new MaintenanceRequest
            {
               Initiator = new Person { FirstName = "Jane", LastName = "Doe",
                  Address = new Address { Address1 = "7 Joe Ln", ApartmentNumber = "2N", City = "Reston", State = "VA", ZipCode = "12345" } },
               Description = "Dishwasher does not work",
               DateSubmitted = DateTime.Now,
               Status = StatusEnum.PENDING
            };

            var request2 = new MaintenanceRequest
            {
               Initiator = new Person { FirstName = "Jane", LastName = "Doe",
                  Address = new Address { Address1 = "5 Joe Ln", ApartmentNumber = "2N", City = "Reston", State = "VA", ZipCode = "12345" } },
               Description = "Dishwasher does not work",
               DateSubmitted = DateTime.Now,
               Status = StatusEnum.PENDING
            };

            Assert.IsFalse(request1.Equals(request2));
        }

        [Test]
        public void MaintenanceRequestGetHashCodeTest()
        {
            var request1 = new MaintenanceRequest
            {
               Initiator = new Person { FirstName = "Jane", LastName = "Doe",
                  Address = new Address { Address1 = "7 Joe Ln", ApartmentNumber = "2N", City = "Reston", State = "VA", ZipCode = "12345" } },
               Description = "Dishwasher does not work",
               DateSubmitted = DateTime.Now,
               Status = StatusEnum.PENDING
            };
         
            var actual = request1.GetHashCode();
            Assert.IsTrue(actual != 0);
        }

        [Test]
        public void MaintenanceRequestToStringTest()
        {
            var request1 = new MaintenanceRequest
            {
                Initiator = new Person { FirstName = "Jane", LastName = "Doe",
                   Address = new Address { Address1 = "7 Joe Ln", ApartmentNumber = "2N", City = "Reston", State = "VA", ZipCode = "12345" } },
                Description = "Dishwasher does not work",
                DateSubmitted = DateTime.Now,
                Status = StatusEnum.PENDING
            };
            var actual = request1.ToString();
            Assert.IsNotNull(actual);
        }
    }
}
