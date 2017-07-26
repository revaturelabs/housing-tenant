using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using HousingTenant.Data.Service.Controllers;
using HousingTenant.Data.Service.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace HousingTenant.Data.Tests.Service.Controllers
{
    [TestFixture]
    public class RequestCtrlTest
    {
        HttpClient client = new HttpClient { BaseAddress = new Uri ("https://housingtenantdata.azurewebsites.net/api/") };

        [Test]
        public async void GetAllTest()
        {
            var requests = await client.GetAsync ("request", HttpCompletionOption.ResponseContentRead);
            var actual = JsonConvert.DeserializeObject<List<RequestDAO>> (requests.Content.ReadAsStringAsync ().Result);
            var expected = 0;

            Assert.IsTrue (actual.Count > expected);
        }
    }
}
