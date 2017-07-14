using System;
using System.Collections.Generic;

namespace HousingTenant.Data.Library.Models
{
    public partial class RequestLookup
    {
        public RequestLookup()
        {
            Request = new HashSet<Request>();
        }

        public int RequestLookupId { get; set; }
        public string RequestType { get; set; }

        public virtual ICollection<Request> Request { get; set; }
    }
}
