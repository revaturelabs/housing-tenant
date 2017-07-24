using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousingTenant.Data.Service.Interfaces;

namespace HousingTenant.Data.Service.Models
{
    public class PersonDAO : IModel
    {
        public int Gender { get; set; }
        public bool HasCar { get; set; }
        public string FirstName { set; get; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime ArrivalDate { get; set; }
    }
}
