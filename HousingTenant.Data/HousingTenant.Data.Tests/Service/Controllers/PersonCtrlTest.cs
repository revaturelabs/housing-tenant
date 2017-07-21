using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using HousingTenant.Data.Service.Controllers;
using HousingTenant.Data.Service.Models;

namespace HousingTenant.Data.Tests.Service.Controllers
{
    [TestFixture]
    public class PersonCtrlTest
    {
        private PersonController pc;

        public PersonCtrlTest()
        {
            pc = new PersonController ();
        }

        [Test]
        public void GetAllTest()
        {
            var expected = pc.Get ();
            var actual = 0;

            Assert.IsTrue (expected.Count > actual);
        }

        [Test]
        public void GetSpecificTest()
        {
            var expected = pc.Get ("Jason");
            var actual = 0;

            Assert.IsTrue (expected.Count > actual);
        }

        [Test]
        public void PostTest()
        {
            Assert.IsTrue (pc.Post (new PersonDAO { FirstName = "some"}));
        }
    }
}
