﻿using HousingTenant.Business.Library.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Tests.RequestTests
{
    [TestFixture]
    public class BusinessLibrarySupplyRequestTests
   {
        static string[] GENDER = new string[] { "OTHER", "MALE", "FEMALE" };
        static string[] STATUS = new string[] { "PENDING", "HOLD", "COMPLETED", "REJECTED" };
        [Test]
        public void SupplyRequestCompareToPositiveTest()
        {
         var request1 = new SupplyRequest
         {
            Initiator = new Person
            {
               FirstName = "Jane",
               LastName = "Doe",
               Address = new Address { Address1 = "7 Joe Ln", ApartmentNumber = "2N", City = "Reston", State = "VA", ZipCode = "12345" }
            },
            DateSubmitted = DateTime.Now,
            Status = STATUS[0]
         };

         var request2 = new SupplyRequest
         {
            Initiator = new Person
            {
               FirstName = "Jane",
               LastName = "Doe",
               Address = new Address { Address1 = "7 Joe Ln", ApartmentNumber = "2N", City = "Reston", State = "VA", ZipCode = "12345" }
            },
            DateSubmitted = DateTime.Now,
            Status = STATUS[0]
         };

         Assert.IsTrue(request1.CompareTo(request2) == 0);
      }

      [Test]
      public void SupplyRequestCompareToNegativeTest()
      {
         var request1 = new SupplyRequest
         {
            Initiator = new Person
            {
               FirstName = "Jane",
               LastName = "Doe",
               Address = new Address { Address1 = "7 Joe Ln", ApartmentNumber = "2N", City = "Reston", State = "VA", ZipCode = "12345" }
            },
            DateSubmitted = DateTime.Now,
            Status = STATUS[0]
         };

         var request2 = new SupplyRequest
         {
            Initiator = new Person
            {
               FirstName = "Jane",
               LastName = "Doe",
               Address = new Address { Address1 = "5 Joe Ln", ApartmentNumber = "2N", City = "Reston", State = "VA", ZipCode = "12345" }
            },
            DateSubmitted = DateTime.Now,
            Status = STATUS[0]
         };

         Assert.IsFalse(request1.CompareTo(request2) < 0);
      }

      [Test]
      public void SupplyRequestToStringTest()
      {
         var request1 = new SupplyRequest
         {
            Initiator = new Person
            {
               FirstName = "Jane",
               LastName = "Doe",
               Address = new Address { Address1 = "7 Joe Ln", ApartmentNumber = "2N", City = "Reston", State = "VA", ZipCode = "12345" }
            },
            DateSubmitted = DateTime.Now,
            Status = STATUS[0]
         };
         var actual = request1.ToString();
         Assert.IsNotNull(actual);
      }
   }
}
