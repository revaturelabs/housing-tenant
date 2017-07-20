using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousingTenant.Data.Service.Interfaces;

namespace HousingTenant.Data.Service.Models
{
    public class PersonDTO : IModel
    {
        public string FirstName { set; get; }
        public string LastName { get; set; }
    }
}
