using System;
using System.Collections.Generic;

namespace HousingTenant.Data.Library.AzModels
{
    public partial class RequestType
    {
        public RequestType()
        {
            Request = new HashSet<Request>();
        }

        public int RequestTypeId { get; set; }
        public string RequestType1 { get; set; }

        public virtual ICollection<Request> Request { get; set; }
    }
}
