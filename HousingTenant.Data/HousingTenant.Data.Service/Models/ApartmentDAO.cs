using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousingTenant.Data.Service.Interfaces;
using HousingTenant.Data.Service.Models;

namespace HousingTenant.Data.Service.Models
{
    public class ApartmentDAO : IModel
    {
        public int Beds { get; set; }
        public int Bathrooms { get; set; }
        public string ApartmentId { get; set; }
        public string ComplexName { get; set; }
        public AddressDAO Address { get; set; }
    }
}
