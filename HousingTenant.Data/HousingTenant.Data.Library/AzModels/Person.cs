using System;
using System.Collections.Generic;

namespace HousingTenant.Data.Library.AzModels
{
    public partial class Person
    {
        public Person()
        {
            RequestInitiatorNavigation = new HashSet<Request>();
            RequestPersonIdAccusedNavigation = new HashSet<Request>();
        }

        public int PersonId { get; set; }
        public Guid Personguid { get; set; }
        public int? AddressId { get; set; }
        public int GenderId { get; set; }
        public bool HasCar { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime ArrivalDate { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Request> RequestInitiatorNavigation { get; set; }
        public virtual ICollection<Request> RequestPersonIdAccusedNavigation { get; set; }
        public virtual Address Address { get; set; }
        public virtual Gender Gender { get; set; }
    }
}
