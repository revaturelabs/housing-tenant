using HousingTenant.Business.Library.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Tests.RequestTests.ComplaintTest
{
  [TestFixture]
  public class ComplaintRequestModelTest
  {
    [Test]
    public void ComplaintTests()
    {
      ComplaintRequest cr = new ComplaintRequest();

      cr.Content = "This is some test content.";
      cr.Status = true;

      Assert.IsNotNull(cr);
    }
  }
}
