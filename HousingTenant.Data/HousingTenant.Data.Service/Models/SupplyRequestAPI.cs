using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousingTenant.Data.Service.Models
{
    public class SupplyRequestAPI
    {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<bool> Supplies { get; set; }
    public string Content { get; set; }
    public DateTime TimeOfRequest { get; set; }
  }
}
