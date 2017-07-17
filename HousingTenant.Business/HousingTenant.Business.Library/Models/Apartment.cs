using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Library.Models
{
  public class Apartment
  {
    public string ComplexName { get; set; }
    public Address Address { get; set; }
    public int NumBeds { get; set; }
    public Gender Gender { get; set; }
    public bool WalkingDistance { get; set; }
  }
}
