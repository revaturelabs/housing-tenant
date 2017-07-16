using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Library.Models
{
  public class Maintenance
  {
    public string Content { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MaintenanceType { get; set; }
    public DateTime TimeOfRequest { get; set; }
  }
}
