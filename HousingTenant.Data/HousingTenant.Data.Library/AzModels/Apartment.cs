using System;
using System.Collections.Generic;

namespace HousingTenant.Data.Library.AzModels
{
    public partial class Apartment
    {
        public Apartment()
        {
            Request = new HashSet<Request>();
        }

        public int ApartmentId { get; set; }
        public Guid Apartmentguid { get; set; }
        public int AddressId { get; set; }
        public int ApartmentComplexId { get; set; }
        public int NumberofBeds { get; set; }
        public int NumberofBathroom { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Request> Request { get; set; }
        public virtual Address Address { get; set; }
        public virtual ApartmentComplex ApartmentComplex { get; set; }
    }
}
