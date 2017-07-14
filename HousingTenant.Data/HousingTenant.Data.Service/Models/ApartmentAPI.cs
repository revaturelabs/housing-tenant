using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousingTenant.Data.Service.Models
{
  public class ApartmentAPI
    {
      public AddressAPI Address { get; set; }
      public bool WalkingDistance { get; set; }
      public int NumBeds { get; set; }
      public Gender AGender { get; set; }
      public string ComplexName { get; set; }
      public int NumCars { get; set; }
    }
}
