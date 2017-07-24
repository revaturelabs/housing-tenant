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
        public void MaintenanceRequestCompareToPositiveTest()
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

            Assert.IsTrue(request1.CompareTo(request2) == 0);
        }

        [Test]
        public void MaintenanceRequestCompareToNegativeTest()
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

            Assert.IsFalse(request1.CompareTo(request2) < 0);
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
