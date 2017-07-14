using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using HousingTenant.Data.Library.DataModels;

namespace HousingTenant.Data.Tests.ModelTests
{
    [TestFixture]
    public class ApartmentTests
    {
        [Test]
        public void CreateApartment()
        {
            Apartment test = new Apartment();

            Assert.IsNotNull(test);
        }

        [Test]
        public void AssignApartment()
        {
            var test = new Apartment();

            test.address = new Address();
            test.complexString = "Something neat";
            test.gender = "male";
            test.numBeds = 5;
            test.numCars = 1;
            test.walkingDist = true;

            Assert.IsNotEmpty(test.gender);
            Assert.IsNotNull(test.address);
            Assert.IsTrue(test.walkingDist);
            Assert.IsNotEmpty(test.complexString);
        }
    }
}
