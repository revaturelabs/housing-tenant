using HousingTenant.Business.Library.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Tests.RequestTests
{
    [TestFixture]
    public class BusinessLibraryComplaintRequestTests
    {
        [Test]
        public void ComplaintRequestEqualsPositiveTest()
        {
            var request1 = new ComplaintRequest
            {
                Accused = new Person { FirstName = "John", LastName = "Doe" },
                Initiator = new Person { FirstName = "Jane", LastName = "Doe" },
                Complaint = "He hit me!",
                DateSubmitted = DateTime.Now,
                Status = StatusEnum.PENDING
            };

            var request2 = new ComplaintRequest
            {
                Accused = new Person { FirstName = "John", LastName = "Doe" },
                Initiator = new Person { FirstName = "Jane", LastName = "Doe" },
                Complaint = "He hit me!",
                DateSubmitted = DateTime.Now,
                Status = StatusEnum.PENDING
            };

            Assert.IsTrue(request1.Equals(request2));
        }

        [Test]
        public void ComplaintRequestEqualsNegativeTest()
        {
            var request1 = new ComplaintRequest
            {
                Accused = new Person { FirstName = "John", LastName = "Doe" },
                Initiator = new Person { FirstName = "Jane", LastName = "Doe" },
                Complaint = "He hit me!",
                DateSubmitted = DateTime.Now,
                Status = StatusEnum.PENDING
            };

            var request2 = new ComplaintRequest
            {
                Accused = new Person { FirstName = "John", LastName = "Doe" },
                Initiator = new Person { FirstName = "James", LastName = "Doe" },
                Complaint = "He hit me!",
                DateSubmitted = DateTime.Now,
                Status = StatusEnum.PENDING
            };

            Assert.IsFalse(request1.Equals(request2));
        }
        
        [Test]
        public void ComplaintRequestGetHashCodeTest()
        {
            var request1 = new ComplaintRequest
            {
                Accused = new Person { FirstName = "John", LastName = "Doe" },
                Initiator = new Person { FirstName = "Jane", LastName = "Doe" },
                Complaint = "He hit me!",
                DateSubmitted = DateTime.Now,
                Status = StatusEnum.PENDING
            };

            var actual = request1.GetHashCode();
            Assert.IsTrue(actual > 0);
        }
        
        [Test]
        public void ComplaintRequestToStringTest()
        {
            var request1 = new ComplaintRequest
            {
               Accused = new Person { FirstName = "John", LastName = "Doe" },
               Initiator = new Person { FirstName = "Jane", LastName = "Doe" },
               Complaint = "He hit me!",
               DateSubmitted = DateTime.Now,
               Status = StatusEnum.PENDING
            };
            var actual = request1.ToString();
            Assert.IsNotNull(actual);
        }
    }
}
