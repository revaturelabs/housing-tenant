using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using HousingTenant.Data.Service.Controllers;
using HousingTenant.Data.Service.Models;

namespace HousingTenant.Data.Tests.Service.Controllers
{
    [TestFixture]
    public class RequestCtrlTest
    {
        [Test]
        public void GetAllTest()
        {
            var ctrl = new RequestController ();
            var actual = new List<RequestDAO>();
            var expected = 0;

            actual = ctrl.Get ();

            Assert.IsTrue (actual.Count > expected);
        }
    }
}
