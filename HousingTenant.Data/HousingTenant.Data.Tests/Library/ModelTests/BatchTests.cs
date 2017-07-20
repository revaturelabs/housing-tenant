using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using HousingTenant.Data.Library.DataModels;

namespace HousingTenant.Data.Tests.ModelTests
{
    [TestFixture]   
    public class BatchTests
    {
        [Test]
        public void CreateBatch()
        {
            var test = new Batch();

            Assert.IsNotNull(test);
        }
    }
}
