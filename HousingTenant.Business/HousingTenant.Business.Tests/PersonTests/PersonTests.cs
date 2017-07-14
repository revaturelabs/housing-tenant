using HousingTenant.Business.Library.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Tests.PersonTests
{
  [TestFixture]
  public class PersonTests
  {
    [Test]
    public void PersonModelPropertiesTest()
    {
      Person p = new Person();

      p.FirstName = "Daniel";
      p.LastName = "Larner";
      p.Gender = Gender.male;
      p.PhoneNumber = "1234567890";
      p.Address = new List<Address>();
      p.Apartment = "Worldgate";
      p.Arrival = new DateTime();
      p.BatchName = "Dotnet";
      p.HasCar = true;

      Assert.IsNotNull(p);
    }
  }
}
