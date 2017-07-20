using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousingTenant.Data.Service.Interfaces;

namespace HousingTenant.Data.Service.Models
{
    public class AddressDTO : IModel
    {
        public string Street1 { set; get; }
        public string Street2 { get; set; }
    }
}
