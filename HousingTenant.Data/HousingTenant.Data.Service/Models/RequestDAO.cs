using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousingTenant.Data.Service.Enum;

namespace HousingTenant.Data.Service.Models
{
    public class RequestDAO
    {
        public bool Urgent { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string RequestorName { get; set; }
        public int PropertyId { get; set; }
        public string RepName { get; set; }
        public string Action { get; set; }

        public RequestType Type { get; set; }
        public Status Status { get; set; }
    }
}
