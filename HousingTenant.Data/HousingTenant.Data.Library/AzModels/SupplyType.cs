using System;
using System.Collections.Generic;

namespace HousingTenant.Data.Library.AzModels
{
    public partial class SupplyType
    {
        public SupplyType()
        {
            SupplyRequest = new HashSet<SupplyRequest>();
        }

        public int SupplyTypeId { get; set; }
        public string Supply { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<SupplyRequest> SupplyRequest { get; set; }
    }
}
