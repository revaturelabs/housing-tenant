using System;
using System.Collections.Generic;

namespace HousingTenant.Data.Library.AzModels
{
    public partial class Address
    {
        public Address()
        {
            Apartment = new HashSet<Apartment>();
            ApartmentComplex = new HashSet<ApartmentComplex>();
            Person = new HashSet<Person>();
        }

        public int AddressId { get; set; }
        public Guid Addressguid { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ApartmentNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Apartment> Apartment { get; set; }
        public virtual ICollection<ApartmentComplex> ApartmentComplex { get; set; }
        public virtual ICollection<Person> Person { get; set; }
    }
}
