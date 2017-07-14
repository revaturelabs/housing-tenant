using System;
using System.Collections.Generic;

namespace HousingTenant.Data.Library.Models
{
    public partial class Complaint
    {
        public int RequestId { get; set; }
        public string Content { get; set; }
        public bool Active { get; set; }
    }
}
