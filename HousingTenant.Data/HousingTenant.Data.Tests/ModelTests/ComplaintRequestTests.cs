using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using HousingTenant.Data.Library.DataModels;

namespace HousingTenant.Data.Tests.ModelTests
{
    [TestFixture]
    public class ComplaintRequestTests
    {
        [Test]
        public void CreateComplaintRequest()
        {
            ComplaintRequest test = new ComplaintRequest();

            Assert.IsNotNull(test);
        }
    }
}
