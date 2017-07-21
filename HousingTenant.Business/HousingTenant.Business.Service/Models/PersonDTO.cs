using HousingTenant.Business.Library.Models;
using System;

namespace HousingTenant.Business.Service.Models
{
    public class PersonDTO
    {
        public int Gender { get; set; }
        public bool HasCar { get; set; }
        public string PersonDTOId { get; set; }
        public string FirstName { set; get; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime ReportDate { get; set; }
        public Address Address { get; set; }
    }
}
