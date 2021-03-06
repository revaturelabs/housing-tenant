﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousingTenant.Data.Service.Enum;
using HousingTenant.Data.Service.Interfaces;

namespace HousingTenant.Data.Service.Models
{
    public class RequestDAO : IModel
    {
        public bool Urgent { get; set; }
        public PersonDAO Initiator { get; set; }
        public DateTime DateSubmitted { get; set; }
        public DateTime DateModified { get; set; }
        public string Status { get; set; }
        public PersonDAO Accused { get; set; }
        public string ApartmentId { get; set; }
        public string RequestId { get; set; }
        public string Description { get; set; }
        public AddressDAO RequestedApartmentAddress { get; set; }
        public List<string> RequestItems { get; set; }
        public string Type { get; set; }
    }
}
