using System;
using System.Collections.Generic;

namespace HousingTenant.Data.Library.Models
{
    public partial class Request
    {
        public int RequestId { get; set; }
        public int RequestLookupId { get; set; }
        public int PersonId { get; set; }
        public DateTime Time { get; set; }
        public bool Active { get; set; }

        public virtual Maintenance Maintenance { get; set; }
        public virtual Supplies Supplies { get; set; }
        public virtual Person Person { get; set; }
        public virtual RequestLookup RequestLookup { get; set; }
    }
}
