using System;
using System.Collections.Generic;
using HousingTenant.Business.Library.Models;

namespace HousingTenant.Business.Service.Models
{
    public class RequestDTO
    {
        public bool Urgent { get; set; }
        public Person Initiator { get; set; }
        public DateTime DateSubmitted { get; set; }
        public DateTime DateModified { get; set; }
        public StatusEnum Status { get; set; }
        public Person Accused { get; set; }
        public string ApartmentId { get; set; }
        public string RequestId { get; set; }
        public string Description { get; set; }
        public Address RequestedApartmentAddress { get; set; }
        public List<string> RequestItems { get; set; }
        public int Type { get; set; }
    }
}
