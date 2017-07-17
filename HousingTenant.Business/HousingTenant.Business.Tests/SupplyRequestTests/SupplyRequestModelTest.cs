using HousingTenant.Business.Library.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Tests.SupplyRequestTests
{
  [TestFixture]
  public class SupplyRequestModelTest
  {
    [Test]
    public void SupplyModelTest()
    {
      SupplyRequest sr = new SupplyRequest();

      sr.Soap = true;
      sr.PaperTowels = true;
      sr.TrashBags = true;
      sr.Sponges = true;
      sr.Content = "This is some test content";
      sr.Status = true;

      Assert.IsTrue(sr.Soap);
      Assert.IsTrue(sr.PaperTowels);
      Assert.IsTrue(sr.TrashBags);
      Assert.IsTrue(sr.Sponges);
      Assert.IsNotNull(sr.Content);
      Assert.IsTrue(sr.Status);
    }
  }
}
