using HousingTenant.Business.Library.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Tests.BatchTests
{
  [TestFixture]
  public class BatchModelTests
  {
    [Test]
    public void BatchModelTest()
    {
      Batch b = new Batch();

      Assert.IsNotNull(b);
    }

    [Test]
    public void BatchModelTest1()
    {
      Batch b = new Batch();

      b.BatchName = "Dotnet";
      b.StartTime = DateTime.Now;
      b.EndTime = DateTime.Now;

      Assert.IsNotEmpty(b.BatchName);
      Assert.IsNotNull(b.StartTime);
      Assert.IsNotNull(b.EndTime);
    }
  }
}
