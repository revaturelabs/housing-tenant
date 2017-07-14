using System;
using System.Collections.Generic;

namespace HousingTenant.Data.Library.Models
{
    public partial class ApartmentComplex
    {
        public ApartmentComplex()
        {
            Apartment = new HashSet<Apartment>();
        }

        public int ApartmentComplexId { get; set; }
        public int AddressId { get; set; }
        public bool WalkingDistance { get; set; }
        public string ComplexName { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Apartment> Apartment { get; set; }
        public virtual Address Address { get; set; }
    }
}
