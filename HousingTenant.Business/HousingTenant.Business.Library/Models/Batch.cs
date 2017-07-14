using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Library.Models
{
  public class Batch
  {
    public string BatchName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
  }
}
