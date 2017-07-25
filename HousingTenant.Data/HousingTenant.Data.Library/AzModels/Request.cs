using System;
using System.Collections.Generic;

namespace HousingTenant.Data.Library.AzModels
{
    public partial class Request
    {
        public Request()
        {
            SupplyRequest = new HashSet<SupplyRequest>();
        }

        public int RequestId { get; set; }
        public Guid Requestguid { get; set; }
        public int RequestTypeId { get; set; }
        public bool IsUrgent { get; set; }
        public int Initiator { get; set; }
        public DateTime DateSubmitted { get; set; }
        public int? PersonIdAccused { get; set; }
        public string Description { get; set; }
        public DateTime? DateModified { get; set; }
        public int StatusId { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<SupplyRequest> SupplyRequest { get; set; }
        public virtual Person InitiatorNavigation { get; set; }
        public virtual Person PersonIdAccusedNavigation { get; set; }
        public virtual RequestType RequestType { get; set; }
    }
}
