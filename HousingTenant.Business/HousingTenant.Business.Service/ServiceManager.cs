using HousingTenant.Business.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousingTenant.Business.Service
{
    public class ServiceManager
    {
        private List<IPerson> Persons = new List<IPerson> {
           new Person{ FirstName = "John", LastName = "Doe", Address = new Address{ } },
           new Person{ },
           new Person{ },
           new Person{ }
        };
        private List<ARequest> Requests = new List<ARequest> { };
        private List<IApartment> Apartments = new List<IApartment> { };
        
        public List<IPerson> GetPerson()
        {
            return Persons;
        }

        public List<IApartment> GetApartments()
        {
            var supplyList = new List<string> {"Soap", "Dishwashing Liquid", "Scruby Pad", "Paper Towel", "Toilet Paper" };

            var address1 = new Address { Address1 = "7 James Ave.", ApartmentNumber = "2A", City = "Reston", State = "VA", ZipCode = "12345" };
            var address2 = new Address { Address1 = "7 James Ave.", ApartmentNumber = "2B", City = "Reston", State = "VA", ZipCode = "12345" };
            var address3 = new Address { Address1 = "7 James Ave.", ApartmentNumber = "2C", City = "Reston", State = "VA", ZipCode = "12345" };
            var address4 = new Address { Address1 = "7 James Ave.", ApartmentNumber = "2D", City = "Reston", State = "VA", ZipCode = "12345" };

            var person1 = new Person { FirstName = "John", LastName = "Doe",
               Address = address1, EmailAddress = "john@doe.com", PhoneNumber = "(235)123-3256", Gender = GenderEnum.FEMALE, ReportDate = DateTime.Now, HasCar = false };
            var person2 = new Person { FirstName = "Paul", LastName = "Carr",
               Address = address1, EmailAddress = "paul@carr.com", PhoneNumber = "(775)123-3256", Gender = GenderEnum.FEMALE, ReportDate = DateTime.Now, HasCar = true };
            var person3 = new Person { FirstName = "Kevin", LastName = "Jones",
               Address = address1, EmailAddress = "john@doe.com", PhoneNumber = "(235)123-3256", Gender = GenderEnum.FEMALE, ReportDate = DateTime.Now, HasCar = false };
            var person4 = new Person { FirstName = "Peter", LastName = "Towns",
               Address = address1, EmailAddress = "john@doe.com", PhoneNumber = "(235)123-3256", Gender = GenderEnum.FEMALE, ReportDate = DateTime.Now, HasCar = true };

            var persList1 = new List<IPerson> { person1, person2, person3, person4 };

            var request1 = new ComplaintRequest { Initiator = person1, Accused = person2,
               Description = "Person1 is accusing Person2", DateSubmitted = DateTime.Now, Status = StatusEnum.PENDING, Urgent = false };
            var request2 = new MaintenanceRequest { Initiator = person2,
               Description = "Need my toilet fixed said person2", DateSubmitted = DateTime.Now, Status = StatusEnum.PENDING, Urgent = false };
            var request3 = new MoveRequest { Initiator = person3,
               Description = "Person3 request move to address2", RequestedApartmentAddress = address2, DateSubmitted = DateTime.Now, Status = StatusEnum.PENDING, Urgent = false };
            var request4 = new SupplyRequest { Initiator = person4,
               Description = "Person4 requesed supplies", RequestItems = supplyList, DateSubmitted = DateTime.Now, Status = StatusEnum.PENDING, Urgent = false };

            var reqsList1 = new List<ARequest> { request1, request2, request4};
            var reqsList2 = new List<ARequest> { request2, request3};
            
            var apartments = new List<IApartment> {
               new Apartment{ Address = address1, Beds = 6, Bathrooms = 2, ComplexName = "Repo Apartment", Persons = persList1, Requests = reqsList1 },
               new Apartment{ Address = address2, Beds = 5, Bathrooms = 2, ComplexName = "Stat Apartment", Requests = reqsList2 }
            };

            return apartments;
        }

        public List<ARequest> GetRequests()
        {
            return Requests;
        }
    }
}
