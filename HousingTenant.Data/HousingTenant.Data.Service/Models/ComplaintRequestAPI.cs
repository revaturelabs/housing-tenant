using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousingTenant.Data.Service.Models
{
    public class ComplaintRequestAPI
    {
      public string Content { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public DateTime TimeOfRequest { get; set; }
    }
}
