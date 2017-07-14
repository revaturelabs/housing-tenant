using System;
using System.Collections.Generic;

namespace HousingTenant.Data.Library.Models
{
    public partial class BatchLookup
    {
        public BatchLookup()
        {
            Batch = new HashSet<Batch>();
        }

        public int BatchLookupId { get; set; }
        public string BatchType { get; set; }

        public virtual ICollection<Batch> Batch { get; set; }
    }
}
