using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousingTenant.Data.Service.Interfaces;
using HousingTenant.Data.Service.Models;

namespace HousingTenant.Data.Service.Models
{
    public class PersonDAO : IModel
    {
        public bool HasCar { get; set; }
        public string PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string ApartmentId { get; set; }
        public AddressDAO Address { get; set; }
        public string Gender { get; set; }
        public DateTime ArrivalDate { get; set; }
    }
}
