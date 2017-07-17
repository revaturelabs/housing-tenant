using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Library.Models
{
  public class Request
  {
    public Person person { get; set; }
    //public Apartment Apartment { get; set; }
    public string Content { get; set; }
    public string RequestType { get; set; }
    public DateTime Time { get; set; }
    public bool Status { get; set; }
  }
}
