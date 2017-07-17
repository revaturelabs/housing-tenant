using HousingTenant.Business.Library.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Tests.RequestTests.RequestTests
{
  [TestFixture]
  public class RequestModelTests
  {
    [Test]
    public void RequestModelClassTests()
    {
      Request r = new Request();

      r.person = new Person();
      r.Content = "This is test content";
      r.RequestType = "Maintenance";
      r.Time = DateTime.Now;
      r.Status = true;

      Assert.IsNotNull(r.person);
      Assert.IsNotEmpty(r.Content);
      Assert.IsNotEmpty(r.RequestType);
      Assert.IsNotNull(r.Time);
      Assert.IsTrue(r.Status);
    }
  }
}
