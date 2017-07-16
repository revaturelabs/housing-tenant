using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousingTenant.Data.Service.Models
{
    public class MaintenanceRequestAPI
    {
      public string Content { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string MaintenanceType { get; set; }
      public DateTime TimeOfRequest { get; set; }
    }
}
