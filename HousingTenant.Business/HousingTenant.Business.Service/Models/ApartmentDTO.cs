using HousingTenant.Business.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousingTenant.Business.Service.Models
{
    public class ApartmentDTO
    {
         public List<PersonDTO> Persons { get; set; }
         public List<RequestDTO> Requests { get; set; }

         public int Beds { get; set; }
         public int Bathrooms { get; set; }
         public string ApartmentId { get; set; }
         public string ComplexName { get; set; }
         public Address Address { get; set; }
   }
}
