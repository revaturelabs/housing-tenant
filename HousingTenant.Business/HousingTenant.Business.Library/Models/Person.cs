using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Library.Models
{
  public enum Gender { male, female }

  public class Person
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
    public string PhoneNumber { get; set; }
    public List<Address> Address { get; set; }
    public string Apartment { get; set; }
    public DateTime Arrival { get; set; }
    public string BatchName { get; set; }
    public List<Request> Request { get; set; }
    public bool HasCar { get; set; }
  }
}
