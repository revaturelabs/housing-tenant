using HousingTenant.Business.Library.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Tests.MaintenanceTest
{
  [TestFixture]
  public class MaintenanceTests
  {
    [Test]
    public void MaintenanceModelTests()
    {
      Maintenance m = new Maintenance();

      m.Content = "This is a text";
      m.FirstName = "Daniel";
      m.LastName = "Larner";
      m.MaintenanceType = "Shower fix";
      m.TimeOfRequest = DateTime.Now;

      Assert.IsNotNull(m);
    }
  }
}
