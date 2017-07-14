using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousingTenant.Data.Service.Models
{
    public class BatchAPI
    {
      public string BatchName { get; set; }
      public DateTime StartDate { get; set; }
      public DateTime EndDate { get; set; }
    }
}
