using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using HousingTenant.Data.Library;

namespace HousingTenant.Data.Tests.DataBrokerTests
{
    [TestFixture]
    public class DataBrokerPersonTests
    {
        [Test]
        public void TestGetPeople()
        {
            DataBroker tb = new DataBroker();

            var data = tb.GetPeopleList();

            foreach(var item in data)
            {
                Console.WriteLine(item.FirstName+'\n');
            }

            Assert.IsNotNull(data);
        }
    }
}
