using System;
using System.Collections.Generic;

namespace HousingTenant.Data.Library.AzModels
{
    public partial class ApartmentComplex
    {
        public ApartmentComplex()
        {
            Apartment = new HashSet<Apartment>();
        }

        public int ApartmentComplexId { get; set; }
        public Guid ApartmentComplexguid { get; set; }
        public int AddressId { get; set; }
        public bool? IsWalkingDistance { get; set; }
        public string ComplexName { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Apartment> Apartment { get; set; }
        public virtual Address Address { get; set; }
    }
}
