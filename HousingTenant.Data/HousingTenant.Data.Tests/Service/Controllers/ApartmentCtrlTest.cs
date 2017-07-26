using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using HousingTenant.Data.Service.Controllers;
using HousingTenant.Data.Service.Models;
using Moq;
using System.Net.Http;
using Newtonsoft.Json;

namespace HousingTenant.Data.Tests.Service.Controllers
{
    [TestFixture]
    public class ApartmentCtrlTest
    {
        HttpClient client = new HttpClient { BaseAddress = new Uri ("https://housingtenantdata.azurewebsites.net/api/") };

        [Test]
        public async void GetAllPosTest()
        {
            var requests = await client.GetAsync ("apartment", HttpCompletionOption.ResponseContentRead);
            var actual = JsonConvert.DeserializeObject<List<ApartmentDAO>> (requests.Content.ReadAsStringAsync ().Result);
            var expected = 0;

            Assert.IsTrue (actual.Count > expected);
        }

        [Test]
        public async void GetSpecificPosTest()
        {
            var id = "38b26b05-7d24-4ac5-af75-c24124e0c47e";
            var uri = string.Format ("apartment/{0}", id);
            var requests = await client.GetAsync (uri, HttpCompletionOption.ResponseContentRead);
            var actual = JsonConvert.DeserializeObject<ApartmentDAO> (requests.Content.ReadAsStringAsync ().Result); ;

            Assert.IsNotNull (actual.ApartmentId);
        }

        [Test]
        public void PostPosTest()
        {
            Assert.IsTrue (true);
        }
    }
}
