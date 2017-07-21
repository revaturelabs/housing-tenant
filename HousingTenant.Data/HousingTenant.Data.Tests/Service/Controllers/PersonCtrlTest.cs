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
        public void GetAllPosTest()
        {
            var expected = pc.Get ();
            var actual = 0;

            Assert.IsTrue (expected.Count > actual);
        }

        [Test]
        public void GetSpecificPosTest()
        {
            var expected = pc.Get ("Jason");
            var actual = 0;

            Assert.IsTrue (expected.Count > actual);
        }

        [Test]
        public void PostPosTest()
        {
            Assert.IsTrue (pc.Post (new PersonDAO { FirstName = "some"}));
        }

        [Test]
        public void GetSpecificNegTest()
        {
            var expected = pc.Get ("Test");
            var actual = 0;

            Assert.IsFalse (expected.Count > actual);
        }

        [Test]
        public void PostNegTest()
        {
            Assert.IsFalse (pc.Post (new PersonDAO { }));
        }
    }
}
