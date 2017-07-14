using System;
using System.Collections.Generic;
using System.Text;
using HousingTenant.Data.Library.DataModels;
using NUnit.Framework;

namespace HousingTenant.Data.Tests.ModelTests
{
    [TestFixture]
    public class PersonTests
    {
        [Test]
        public void PersonExistsTest()
        {
            Person exist = new Person();

            Assert.IsNotNull(exist);
        }

    }
}
