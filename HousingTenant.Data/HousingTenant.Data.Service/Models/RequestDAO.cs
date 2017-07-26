using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousingTenant.Data.Service.Enum;
using HousingTenant.Data.Service.Interfaces;

namespace HousingTenant.Data.Service.Models
{
    public class RequestDAO : IModel
    {
        public Guid Requestguid { get; set; }
        public string RequestType { get; set; }
        public bool IsUrgent { get; set; }
        public PersonDAO Initiator { get; set; }
        public DateTime DateSubmitted { get; set; }
        public List<PersonDAO> PersonAccused { get; set; }
        public string Description { get; set; }
        public DateTime? DateModified { get; set; }
        public string Status { get; set; }
        public List<string> RequestItems { get; set; }
        public Guid ApartmentGuid { get; set; }
    }
}
