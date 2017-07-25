using System;
using System.Collections.Generic;

namespace HousingTenant.Data.Library.AzModels
{
    public partial class SupplyRequest
    {
        public int SupplyRequestId { get; set; }
        public int SupplyTypeId { get; set; }
        public int RequestId { get; set; }
        public bool Active { get; set; }

        public virtual Request Request { get; set; }
        public virtual SupplyType SupplyType { get; set; }
    }
}
