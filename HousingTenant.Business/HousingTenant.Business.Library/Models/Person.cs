using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Library.Models
{
    /// <summary>
    /// Represent a Tenant living in an Apartment provided
    /// by Revature. The following attributes are necessary
    /// for Revature to manage and assign persons to apartments:
    /// -Name
    /// -Gender
    /// -Contact information
    /// -if they have their own transportation
    /// -the date they intend to report
    /// Upon arrival, a person is expected to be provided access
    /// to their assigned apartment
    /// </summary>
    public class Person : IPerson
    {
        public bool HasCar { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime ReportDate { get; set; }


        /// <summary>
        /// Compares two Person for equality using the names of each persons
        /// </summary>
        /// <param name="obj">
        /// The Object that this person is being compared
        /// </param>
        /// <returns>
        /// True if the names of both request are the same,
        /// false otherwise
        /// </returns>
        public override bool Equals(object obj)
        {
             if (obj != null && obj.GetType() == GetType())
             {
                 var newPerson = obj as Person;
                 return newPerson.FirstName.ToLower().Equals(FirstName.ToLower()) &&
                    newPerson.LastName.ToLower().Equals(LastName.ToLower());
             }
             return false;
        }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }

        /// <summary>
        /// Generage a unique number for this object
        /// </summary>
        /// <returns>
        /// A number that represent this object
        /// </returns>
        public override int GetHashCode()
        {
            return FirstName.GetHashCode() + LastName.GetHashCode();
        }

        public bool IsValid()
        {
            return FirstName != null && LastName != null && Address != null;
        }

      /// <summary>
      /// Generate a string representation of this object
      /// </summary>
      /// <returns>
      /// String representation of this object instance
      /// </returns>
      public override string ToString()
        {
            return string.Format("{0} {1}\n{2}\n{3}",
               FirstName, LastName, EmailAddress, PhoneNumber);
        }
    }
}
