using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using HousingTenant.Data.Service.Controllers;
using HousingTenant.Data.Service.Models;
using Moq;


namespace HousingTenant.Data.Tests.Service.Controllers
{
    [TestFixture]
    public class ApartmentCtrlTest
    {
        private ApartmentController ac;

        public ApartmentCtrlTest()
        {
            ac = new ApartmentController ();
        }

        [Test]
        public void GetAllPosTest()
        {
            var expected = ac.Get ();
            var actual = 0;

            Assert.IsTrue (expected.Count > actual);
        }

        [Test]
        public void GetSpecificPosTest()
        {
            var expected = ac.Get ("0");
            var actual = 1;

            Assert.IsTrue (expected.Count == actual);
        }

        [Test]
        public void PostPosTest()
        {
            Assert.IsTrue (ac.Post (new ApartmentDAO { Address = new AddressDAO()}));
        }

        [Test]
        public void GetSpecificNegTest()
        {
            var expected = ac.Get ("-1");
            var actual = 0;

            Assert.IsFalse (expected.Count > actual);
        }

        [Test]
        public void PostNegTest()
        {
            Assert.IsFalse (ac.Post (new ApartmentDAO { }));
        }
    }
}
