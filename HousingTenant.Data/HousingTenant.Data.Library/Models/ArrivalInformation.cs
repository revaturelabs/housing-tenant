using System;
using System.Collections.Generic;

namespace HousingTenant.Data.Library.Models
{
    public partial class ArrivalInformation
    {
        public int ArrivalInformationId { get; set; }
        public int BatchId { get; set; }
        public int PersonId { get; set; }
        public DateTime ArrivalDate { get; set; }
        public TimeSpan? ArrivalTime { get; set; }
        public bool HasCar { get; set; }

        public virtual Batch Batch { get; set; }
        public virtual Person Person { get; set; }
    }
}
