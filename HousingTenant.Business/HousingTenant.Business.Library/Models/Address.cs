using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Library.Models
{
    public class Address
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ApartmentNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        /// <summary>
        /// Compares two Address for equality using each property
        /// of the address class
        /// </summary>
        /// <param name="obj">
        /// The object that this Address is being compared
        /// </param>
        /// <returns>
        /// True if all the properties compared are the same,
        /// false otherwise
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj != null && obj.GetType() == GetType())
            {
                var newAddress = obj as Address;
                return newAddress.ApartmentNumber.ToLower().Equals(ApartmentNumber.ToLower()) &&
                   newAddress.Address1.ToLower().Equals(Address1.ToLower()) &&
                   newAddress.City.ToLower().Equals(City.ToLower()) &&
                   newAddress.State.ToLower().Equals(State.ToLower()) &&
                   newAddress.ZipCode.ToLower().Equals(ZipCode.ToLower());
            }
            return false;
        }

        /// <summary>
        /// Generage a unique number for this object
        /// </summary>
        /// <returns>
        /// A number that represent this class
        /// </returns>
        public override int GetHashCode()
        {
            return Address1.GetHashCode() +
               ApartmentNumber.GetHashCode() +
               City.GetHashCode() +
               State.GetHashCode() +
               ZipCode.GetHashCode();
        }

        /// <summary>
        /// Generate a string representation of this class
        /// </summary>
        /// <returns>
        /// String representation of this class instance
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0} Apt {1},\n{2} {3} {4}",
               Address1, ApartmentNumber, City, State, ZipCode);
        }
    }
}
