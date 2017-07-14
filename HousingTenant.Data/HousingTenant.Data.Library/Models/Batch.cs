using System;
using System.Collections.Generic;

namespace HousingTenant.Data.Library.Models
{
    public partial class Batch
    {
        public Batch()
        {
            ArrivalInformation = new HashSet<ArrivalInformation>();
        }

        public int BatchId { get; set; }
        public int BatchLookupId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<ArrivalInformation> ArrivalInformation { get; set; }
        public virtual BatchLookup BatchLookup { get; set; }
    }
}
