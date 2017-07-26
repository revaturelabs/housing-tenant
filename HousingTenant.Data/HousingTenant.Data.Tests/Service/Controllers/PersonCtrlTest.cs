using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using HousingTenant.Data.Service.Controllers;
using HousingTenant.Data.Service.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace HousingTenant.Data.Tests.Service.Controllers
{
    [TestFixture]
    public class PersonCtrlTest
    {
        HttpClient client = new HttpClient { BaseAddress = new Uri ("https://housingtenantdata.azurewebsites.net/api/") };

        [Test]
        public async void GetAllPosTest()
        {
            var requests = await client.GetAsync ("person", HttpCompletionOption.ResponseContentRead);
            var actual = JsonConvert.DeserializeObject<List<PersonDAO>> (requests.Content.ReadAsStringAsync ().Result);
            var expected = 0;

            Assert.IsTrue (actual.Count > expected);
        }

        [Test]
        public async void GetSpecificPosTest()
        {
            var id = "38b26b05-7d24-4ac5-af75-c24124e0c47e";
            var uri = string.Format ("person/{0}", id);
            var requests = await client.GetAsync (uri, HttpCompletionOption.ResponseContentRead);
            var actual = JsonConvert.DeserializeObject<PersonDAO> (requests.Content.ReadAsStringAsync ().Result); ;

            Assert.IsNotNull (actual.PersonId);
        }

        [Test]
        public void PostPosTest()
        {
            Assert.IsTrue (true);
        }
    }
}
