using System;
using System.Collections.Generic;

namespace HousingTenant.Data.Library.Models
{
    public partial class MaintenanceLookup
    {
        public MaintenanceLookup()
        {
            Maintenance = new HashSet<Maintenance>();
        }

        public int MaintenanceTypeId { get; set; }
        public string MaintenanceType { get; set; }

        public virtual ICollection<Maintenance> Maintenance { get; set; }
    }
}
