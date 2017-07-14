using System;
using System.Collections.Generic;

namespace HousingTenant.Data.Library.Models
{
    public partial class Person
    {
        public Person()
        {
            ArrivalInformation = new HashSet<ArrivalInformation>();
            Request = new HashSet<Request>();
        }

        public int PersonId { get; set; }
        public int? ApartmentId { get; set; }
        public int HomeAddressId { get; set; }
        public int GenderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<ArrivalInformation> ArrivalInformation { get; set; }
        public virtual ICollection<Request> Request { get; set; }
        public virtual Apartment Apartment { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Address HomeAddress { get; set; }
    }
}
