using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using HousingTenant.Data.Library.DataModels;

namespace HousingTenant.Data.Tests.ModelTests
{
    [TestFixture]
    public class ArrivalInfoTests
    {
        [Test]
        public void TestCreateArrivalInfo()
        {
            ArrivalInformation test = new ArrivalInformation();

            Assert.IsNotNull(test);

            test.hasCar = true;
            Assert.IsTrue(test.hasCar);
        }
    }
}
