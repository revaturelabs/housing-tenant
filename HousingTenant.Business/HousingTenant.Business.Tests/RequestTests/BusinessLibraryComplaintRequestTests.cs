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
        static string[] GENDER = new string[] { "OTHER", "MALE", "FEMALE" };
        static string[] STATUS = new string[] { "PENDING", "HOLD", "COMPLETED", "REJECTED" };
        [Test]
        public void ComplaintRequestCompareToPositiveTest()
        {
            var request1 = new ComplaintRequest
            {
                Accused = new Person { FirstName = "John", LastName = "Doe" },
                Initiator = new Person { FirstName = "Jane", LastName = "Doe" },
                Description = "He hit me!",
                DateSubmitted = DateTime.Now,
                Status = STATUS[0]
            };

            var request2 = new ComplaintRequest
            {
                Accused = new Person { FirstName = "John", LastName = "Doe" },
                Initiator = new Person { FirstName = "Jane", LastName = "Doe" },
                Description = "He hit me!",
                DateSubmitted = DateTime.Now,
                Status = STATUS[0]
            };

            Assert.IsTrue(request1.CompareTo(request2) == 0);
        }

        [Test]
        public void ComplaintRequestCompareToNegativeTest()
        {
            var request1 = new ComplaintRequest
            {
                Accused = new Person { FirstName = "John", LastName = "Doe" },
                Initiator = new Person { FirstName = "Jane", LastName = "Doe" },
                Description = "He hit me!",
                DateSubmitted = DateTime.Now,
                Status = STATUS[0]
            };

            var request2 = new ComplaintRequest
            {
                Accused = new Person { FirstName = "John", LastName = "Doe" },
                Initiator = new Person { FirstName = "James", LastName = "Doe" },
                Description = "He hit me!",
                DateSubmitted = DateTime.Now,
                Status = STATUS[0]
            };

            Assert.IsFalse(request1.CompareTo(request2) < 0);
        }
        
        [Test]
        public void ComplaintRequestToStringTest()
        {
            var request1 = new ComplaintRequest
            {
               Accused = new Person { FirstName = "John", LastName = "Doe" },
               Initiator = new Person { FirstName = "Jane", LastName = "Doe" },
               Description = "He hit me!",
               DateSubmitted = DateTime.Now,
               Status = STATUS[0]
            };
            var actual = request1.ToString();
            Assert.IsNotNull(actual);
        }
    }
}
