using System;
using System.Collections.Generic;

namespace HousingTenant.Data.Library.Models
{
    public partial class Maintenance
    {
        public int RequestId { get; set; }
        public int MaintenanceTypeId { get; set; }
        public string Content { get; set; }
        public bool Active { get; set; }

        public virtual MaintenanceLookup MaintenanceType { get; set; }
        public virtual Request Request { get; set; }
    }
}
