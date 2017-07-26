using HousingTenant.Business.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousingTenant.Business.Service
{
    public class ServiceManager
   {
      static List<string> supplyList = new List<string> { "Soap", "Dishwashing Liquid", "Scruby Pad", "Paper Towel", "Toilet Paper" };

      static Address address1 = new Address { Address1 = "7 James Ave.", ApartmentNumber = "2A", City = "Reston", State = "VA", ZipCode = "12345" };
      static Address address2 = new Address { Address1 = "7 James Ave.", ApartmentNumber = "2B", City = "Reston", State = "VA", ZipCode = "12345" };
      static Address address3 = new Address { Address1 = "7 James Ave.", ApartmentNumber = "2C", City = "Reston", State = "VA", ZipCode = "12345" };
      static Address address4 = new Address { Address1 = "7 James Ave.", ApartmentNumber = "2D", City = "Reston", State = "VA", ZipCode = "12345" };

      static Person person1 = new Person
      {
         PersonId = "0",
         FirstName = "John",
         LastName = "Doe",
         Address = address1,
         EmailAddress = "john@doe.com",
         PhoneNumber = "(235)123-3256",
         Gender = GenderEnum.FEMALE,
         ArrivalDate = DateTime.Now,
         HasCar = false
      };
      static Person person2 = new Person
      {
         PersonId = "1",
         FirstName = "Paul",
         LastName = "Carr",
         Address = address1,
         EmailAddress = "paul@carr.com",
         PhoneNumber = "(775)123-3256",
         Gender = GenderEnum.FEMALE,
         ArrivalDate = DateTime.Now,
         HasCar = true
      };
      static Person person3 = new Person
      {
         PersonId = "2",
         FirstName = "Kevin",
         LastName = "Jones",
         Address = address1,
         EmailAddress = "john@doe.com",
         PhoneNumber = "(235)123-3256",
         Gender = GenderEnum.FEMALE,
         ArrivalDate = DateTime.Now,
         HasCar = false
      };
      static Person person4 = new Person
      {
         PersonId = "3",
         FirstName = "Peter",
         LastName = "Towns",
         Address = address1,
         EmailAddress = "john@doe.com",
         PhoneNumber = "(235)123-3256",
         Gender = GenderEnum.FEMALE,
         ArrivalDate = DateTime.Now,
         HasCar = true
      };

      static ARequest request1 = new ComplaintRequest
      {
         RequestId = "1",
         Initiator = person1,
         Accused = person2,
         Description = "Person1 is accusing Person2",
         DateSubmitted = DateTime.Now,
         Status = StatusEnum.PENDING,
         Urgent = false
      };
      static ARequest request2 = new MaintenanceRequest
      {
         RequestId = "2",
         Initiator = person2,
         Description = "Need my toilet fixed said person2",
         DateSubmitted = DateTime.Now,
         Status = StatusEnum.PENDING,
         Urgent = false
      };
      static ARequest request3 = new MoveRequest
      {
         RequestId = "3",
         Initiator = person3,
         Description = "Person3 request move to address2",
         RequestedApartmentAddress = address2,
         DateSubmitted = DateTime.Now,
         Status = StatusEnum.PENDING,
         Urgent = false
      };
      static ARequest request4 = new SupplyRequest
      {
         RequestId = "4",
         Initiator = person4,
         Description = "Person4 requesed supplies",
         RequestItems = supplyList,
         DateSubmitted = DateTime.Now,
         Status = StatusEnum.PENDING,
         Urgent = false
      };
      static List<ARequest> reqsList1 = new List<ARequest> { request1, request2, request3, request4 };
      static List<ARequest> reqsList2 = new List<ARequest> { request1, request2, request4 };

      static List<IPerson> persList1 = new List<IPerson> { person1, person2, person3, person4 };

      List<IApartment> apartments = new List<IApartment> {
               new Apartment{ Address = address1, Beds = 6, Bathrooms = 2, ComplexName = "Repo Apartment", Persons = persList1, Requests = reqsList1 },
               new Apartment{ Address = address2, Beds = 5, Bathrooms = 2, ComplexName = "Stat Apartment", Requests = reqsList2 }
      };

      public void AddPerson(IPerson person)
      {
         persList1.Add(person);
      }

      public List<IPerson> GetPersons()
      {
         return persList1;
      }

      public IPerson GetPerson(string id)
      {
         if (int.Parse(id) >= 0 && int.Parse(id) <= 3)
         {
            return persList1[int.Parse(id)];
         }
         return new Person();
      }

      public void AddApartment(IApartment apartment)
      {
         apartments.Add(apartment);
      }

      public List<IApartment> GetApartments()
      {
         var reqsList1 = new List<ARequest> { request1, request2, request4 };
         var reqsList2 = new List<ARequest> { request2, request3 };

         var apartments = new List<IApartment> {
               new Apartment{ Address = address1, Beds = 6, Bathrooms = 2, ComplexName = "Repo Apartment", Persons = persList1, Requests = reqsList1 },
               new Apartment{ Address = address2, Beds = 5, Bathrooms = 2, ComplexName = "Stat Apartment", Requests = reqsList2 }
            };

         return apartments;
      }

      public IApartment GetApartment(string id)
      {
         var reqsList1 = new List<ARequest> { request1, request2, request4 };

         return new Apartment { Address = address1, Beds = 6, Bathrooms = 2, ComplexName = "Repo Apartment", Persons = persList1, Requests = reqsList1 };
      }

      public void AddRequest(ARequest request)
      {
         reqsList1.Add(request);
      }

      public List<ARequest> GetRequests()
      {
         return reqsList1;
      }

      public ARequest GetRequest(string id)
      {
         var request = new SupplyRequest { RequestId = id };
         //if (reqsList1.Contains(request))
         //{
            return reqsList1.Find(r => r.RequestId == id);
         //}
         //return request;
      }

      public List<ARequest> GetRequests(Address address)
      {
         var requestList = new List<ARequest>();
         foreach (var r in reqsList1)
         {
            var p = (Person)r.Initiator;
            if (p.Address.CompareTo(address) == 0)
            {
               requestList.Add(r);
            }
         }
         return requestList;
      }
   }
}
