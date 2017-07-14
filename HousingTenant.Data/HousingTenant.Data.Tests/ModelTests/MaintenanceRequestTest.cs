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
    }
}
