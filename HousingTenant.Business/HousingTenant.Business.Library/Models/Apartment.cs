using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Library.Models
{
    public class Apartment : IApartment, IComparable<Apartment>
    {
        private List<IPerson> _Persons;
        public List<IPerson> Persons { get { return _Persons; } set { _Persons = value; } }

        private List<ARequest> _Requests;
        public List<ARequest> Requests { get { return _Requests; } set { _Requests = value; } }

        public int Beds { get; set; }
        public int Bathrooms { get; set; }
        public string ApartmentId { get; set; }
        public string ComplexName { get; set; }
        public Address Address { get; set; }
        
        public Apartment()
        {
            _Persons = new List<IPerson>();
            _Requests = new List<ARequest>();
        }
        
        public bool AddRequest(ARequest request)
        {
            if(request != null)
            {
                if (!_Requests.Contains(request))
                {
                    _Requests.Add(request);
                    return true;
                }
            }
            return false;
        }

        public bool AddTenant(IPerson tenant)
        {
            if(tenant != null)
            {
                if(!_Persons.Contains(tenant))
                {
                    _Persons.Add(tenant);
                    return true;
                }
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            if(obj != null && obj.GetType() == GetType())
            {
                var newApartment = obj as Apartment;

                return newApartment.Address.Equals(Address);
            }
            return false;
        }

        public override int GetHashCode()
        {
         return Address.GetHashCode();
        }

        public bool IsValid()
        {
            return Beds > 0 && Bathrooms > 0 && Address != null;
        }

        public List<ARequest> OpenRequests()
        {
            var requests = new List<ARequest>();

            foreach (var request in _Requests)
            {
                if(request.Status != StatusEnum.COMPLETED)
                {
                    requests.Add(request);
                }
            }
            return requests;
        }

        public override string ToString()
        {
            return string.Format("{0}\n{1} Beds, {2} Bathrooms",
               Address,Beds,Bathrooms);
        }

      public int CompareTo(Apartment other)
      {
         throw new NotImplementedException();
      }
   }
}
