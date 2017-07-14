using System;
using System.Collections.Generic;

namespace HousingTenant.Data.Library.Models
{
    public partial class Apartment
    {
        public Apartment()
        {
            Person = new HashSet<Person>();
        }

        public int ApartmentId { get; set; }
        public int ApartmentComplexId { get; set; }
        public int AddressId { get; set; }
        public int NumBeds { get; set; }
        public string Gender { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Person> Person { get; set; }
        public virtual Address Address { get; set; }
        public virtual ApartmentComplex ApartmentComplex { get; set; }
    }
}
