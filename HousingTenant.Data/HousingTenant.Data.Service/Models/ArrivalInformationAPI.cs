using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousingTenant.Data.Service.Models
{
    public class ArrivalInformationAPI
    {
      public DateTime ArrivalDate { get; set; }
      public DateTime ArrivalTime { get; set; }
      public bool HasCar { get; set; }
      public BatchAPI Batch { get; set; }
    }
}
