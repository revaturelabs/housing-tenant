using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Library.Models
{
    public class Address : IComparable<Address>
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ApartmentNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        
        public int CompareTo(Address other)
        {
            if(other != null)
            {
                var thisAddressString = string.Format("{0} {1} {2} {3} {4}",
                   Address1, ApartmentNumber, City, State, ZipCode).ToLower();
                var otherAddressString = string.Format("{0} {1} {2} {3} {4}",
                   other.Address1, other.ApartmentNumber, other.City, other.State, other.ZipCode).ToLower();

                return thisAddressString.CompareTo(otherAddressString);
            }
            return -1;
        }
      
        public override string ToString()
        {
            return string.Format("{0} Apt {1},\n{2} {3} {4}",
               Address1, ApartmentNumber, City, State, ZipCode);
        }
    }
}
