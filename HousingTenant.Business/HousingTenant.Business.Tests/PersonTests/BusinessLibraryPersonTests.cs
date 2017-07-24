using HousingTenant.Business.Library.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Tests.PersonTests
{
    [TestFixture]
    public class BusinessLibraryPersonTests
    {
        [Test]
        public void PersonCompareToPositiveTest()
        {
            var person1 = new Person
            {
                FirstName = "John",
                LastName = "Doe"
            };
            var person2 = new Person
            {
                FirstName = "John",
                LastName = "Doe"
            };

            Assert.IsTrue(person1.CompareTo(person2) == 0);
        }

        [Test]
        public void PersonCompareToNegativeTest()
        {
            var person1 = new Person
            {
                FirstName = "John",
                LastName = "Doe"
            };
            var person2 = new Person
            {
                FirstName = "Johnne",
                LastName = "Dae"
            };

            Assert.IsFalse(person1.CompareTo(person2) > 0);
        }

        [Test]
        public void PersonGetFullNameTest()
        {
            var person1 = new Person
            {
               FirstName = "John",
               LastName = "Doe"
            };

            var actual = person1.GetFullName();
            var expected = "John Doe";

            Assert.IsTrue(actual.Equals(expected));
        }
        
        [Test]
        public void PersonToStringTest()
        {
            var person1 = new Person
            {
                FirstName = "John",
                LastName = "Doe"
            };
            var actual = person1.ToString();

            Assert.IsNotNull(actual);
        }
    }
}
