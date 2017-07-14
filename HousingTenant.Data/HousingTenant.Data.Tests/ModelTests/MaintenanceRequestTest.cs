using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using HousingTenant.Data.Library.DataModels;

namespace HousingTenant.Data.Tests.ModelTests
{
    [TestFixture]
    public class MaintenanceRequestTest
    {
        [Test]
        public void CreateMaintenanceRequest()
        {
            var test = new MaintenanceRequest();

            Assert.IsNotNull(test);
        }

        [Test]
        public void SetMaintenanceRequest()
        {
            var test = new MaintenanceRequest();

            test.content = "I am a test object";
            test.firstName = "FirstNameBro";
            test.lastName = "LastNameDude";
            test.timeOfRequest = DateTime.Now;
        }
    }
}
