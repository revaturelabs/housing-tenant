using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousingTenant.Data.Service.Models
{
  public enum Gender { male, female };
  public class PersonAPI
    {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public Gender PGender { get; set; }
      public string Email { get; set; }
      public string PhoneNumber { get; set; }
      public ArrivalInformationAPI ArrivalInformation { get; set; }
      
      
    }
}
