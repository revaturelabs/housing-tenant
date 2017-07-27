using HousingTenant.Business.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousingTenant.Business.Service
{
    public class ServiceManager
   {
      static string[] GENDER = new string[] { "OTHER", "MALE", "FEMALE" };
      static string[] STATUS = new string[] { "PENDING", "HOLD", "COMPLETED", "REJECTED" };
      static List<string> supplyList = new List<string> { "Soap", "Dishwashing Liquid", "Scruby Pad", "Paper Towel", "Toilet Paper" };

      static Address address1 = new Address { Address1 = "2100 Wilkes Court", ApartmentNumber = "102", City = "Herndon", State = "Virginia", ZipCode = "20170" };
      static Address address2 = new Address { Address1 = "2100 Wilkes Court", ApartmentNumber = "101", City = "Herndon", State = "Virginia", ZipCode = "20170" };
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
         Gender = GENDER[2],
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
         Gender = GENDER[2],
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
         Gender = GENDER[2],
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
         Gender = GENDER[2],
         ArrivalDate = DateTime.Now,
         HasCar = true
      };
      static Person person5 = new Person
      {
         PersonId = "4",
         FirstName = "Carl",
         LastName = "Paddle",
         Address = address2,
         EmailAddress = "carl@paddle.com",
         PhoneNumber = "(201)923-3256",
         Gender = GENDER[2],
         ArrivalDate = DateTime.Now,
         HasCar = true
      };
      static Person person6 = new Person
      {
         PersonId = "5",
         FirstName = "Tessa",
         LastName = "Pams",
         Address = address2,
         EmailAddress = "tessa@pams.com",
         PhoneNumber = "(239)123-3256",
         Gender = GENDER[2],
         ArrivalDate = DateTime.Now,
         HasCar = false
      };

      static ARequest request1 = new ComplaintRequest
      {
         RequestId = "0",
         ApartmentId = "0",
         Initiator = person1,
         Accused = person2,
         Description = "Person1 is accusing Person2",
         DateSubmitted = DateTime.Now,
         Status = STATUS[0],
         Urgent = false
      };
      static ARequest request2 = new MaintenanceRequest
      {
         RequestId = "1",
         ApartmentId = "0",
         Initiator = person2,
         Description = "Need my toilet fixed said person2",
         DateSubmitted = DateTime.Now,
         Status = STATUS[0],
         Urgent = false
      };
      static ARequest request3 = new MoveRequest
      {
         RequestId = "2",
         ApartmentId = "0",
         Initiator = person3,
         Description = "Person3 request move to address2",
         RequestedApartmentAddress = address2,
         DateSubmitted = DateTime.Now,
         Status = STATUS[0],
         Urgent = false
      };
      static ARequest request4 = new SupplyRequest
      {
         RequestId = "3",
         ApartmentId = "0",
         Initiator = person4,
         Description = "Person4 requesed supplies",
         RequestItems = supplyList,
         DateSubmitted = DateTime.Now,
         Status = STATUS[0],
         Urgent = false
      };
      static ARequest request5 = new SupplyRequest
      {
         RequestId = "4",
         ApartmentId = "1",
         Initiator = person5,
         Description = "Person5 requesed supplies",
         RequestItems = supplyList,
         DateSubmitted = DateTime.Now,
         Status = STATUS[0],
         Urgent = false
      };

      static List<ARequest> reqsList1 = new List<ARequest> { request1, request2, request3, request4 };
      static List<ARequest> reqsList2 = new List<ARequest> { request5 };
      static List<ARequest> Requests = new List<ARequest> { request1, request2, request3, request4, request5 };

      static List<IPerson> Persons = new List<IPerson> { person1, person2, person3, person4, person5, person6 };
      static List<IPerson> persList1 = new List<IPerson> { person1, person2, person3, person4 };
      static List<IPerson> persList2 = new List<IPerson> { person5, person6 };

      static List<IApartment> apartments = new List<IApartment> {
               new Apartment{ ApartmentId = "0", Address = address1, Beds = 4, Bathrooms = 1, ComplexName = "Demo Apartment", Persons = persList1, Requests = reqsList1 },
               new Apartment{ ApartmentId = "1", Address = address2, Beds = 6, Bathrooms = 2, ComplexName = "Repo Apartment", Persons = persList2, Requests = reqsList2 },
               new Apartment{ ApartmentId = "2", Address = address3, Beds = 5, Bathrooms = 2, ComplexName = "Stat Apartment" }
      };

      public void AddPerson(IPerson person)
      {
         Persons.Add(person);
      }

      public List<IPerson> GetPersons()
      {
         return Persons;
      }

      public List<IPerson> GetPersons(Address address)
      {
         var PersonList = new List<IPerson>();
         if (address.IsValid())
         {
            foreach (var p in Persons)
            {
               var person = p as Person;
               if (person.Address.CompareTo(address) == 0)
               {
                  PersonList.Add(person);
               }
            }
         }
         return PersonList;
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
         return apartments;
      }

      public IApartment GetApartment(string id)
      {
         if (id != null)
         {
            foreach (var ap in apartments)
            {
               var a = ap as Apartment;
               if (a.ApartmentId.Equals(id))
                  return a;
            }
         }
         return new Apartment();
      }

      public IApartment GetApartment(Address address)
      {
         if (address.IsValid())
         {
            foreach (var iapartment in apartments)
            {
               var apartment = iapartment as Apartment;
               if (apartment.Address.CompareTo(address) == 0)
               {
                  return apartment;
               }
            }
         }
         return new Apartment();
      }

      public void AddRequest(ARequest request)
      {
         reqsList1.Add(request);
      }

      public List<ARequest> GetRequests()
      {
         return reqsList1;
      }

      public List<ARequest> GetRequests(string id)
      {
         return Requests.FindAll(r => r.ApartmentId == id);
      }

      public ARequest GetRequest(string id)
      {
         var request = new SupplyRequest { RequestId = id };
         foreach (var r in Requests)
         {
            if (r.ApartmentId == id)
            {

            }
         }
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
