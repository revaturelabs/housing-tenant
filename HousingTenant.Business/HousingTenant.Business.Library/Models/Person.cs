using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Library.Models
{
    public class Person : IPerson
    {
        public bool HasCar { get; set; }
        public string PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
        public string Gender { get; set; } // public GenderEnum Gender { get; set; }
        public DateTime ArrivalDate { get; set; }

        public int CompareTo(IPerson other)
        {
            if(other != null)
            {
                var otherPerson = other as Person;
                var thisPersonString = string.Format("{0} {1} {2}",FirstName,LastName,Gender).ToLower();
                var otherPersonString = string.Format("{0} {1} {2}",
                   otherPerson.FirstName, otherPerson.LastName, otherPerson.Gender).ToLower();

                return thisPersonString.CompareTo(otherPersonString);
            }
            return -1;
        }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }

        public bool IsValid()
        {
            return FirstName != null && LastName != null && Address != null;
        }
      
        public override string ToString()
        {
               return string.Format("{0} {1}\n{2}\n{3}",
                  FirstName, LastName, EmailAddress, PhoneNumber);
        }
    }
}
