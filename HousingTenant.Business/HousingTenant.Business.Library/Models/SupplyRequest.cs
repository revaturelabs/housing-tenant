using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Library.Models
{
  public class SupplyRequest
  {
    public bool Soap { get; set; }
    public bool PaperTowels { get; set; }
    public bool TrashBags { get; set; }
    public bool Sponges { get; set; }
    public string Content { get; set; }
    public bool Status { get; set; }
  }
}
