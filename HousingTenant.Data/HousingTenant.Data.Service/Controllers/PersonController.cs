using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HousingTenant.Data.Service.Models;
using HousingTenant.Data.Library.AzModels;

namespace HousingTenant.Data.Service.Controllers
{
    [Route ("api/[controller]/[action]")]
    public class PersonController : Controller
    {
        /// <summary>
        /// private field containing the DBContext of the database being used
        /// </summary>
        private HousingTenantDBContext _Context;

        /// <summary>
        /// Updates _Context to represent the current state of the database being used.
        /// </summary>
        /// <param name="context"></param>
        public PersonController(HousingTenantDBContext context)
        {
            _Context = context; 
        }

        /// <summary>
        /// Returns all the People that are stored in the database
        /// </summary>
        [HttpGet]
        [ActionName ("GetAll")]
        public List<PersonDAO> Get()
        {
            var person = _Context.Person;
            var gender = _Context.Gender;
            var address = _Context.Address;
            var apartment = _Context.Apartment;

            var output = (from p in person
                          join g in gender on p.GenderId equals g.GenderId
                          join add in address on p.AddressId equals add.AddressId
                          join a in apartment on add.AddressId equals a.AddressId
                          select new PersonDAO
                          {
                              PersonId = p.Personguid.ToString (),
                              ArrivalDate = p.ArrivalDate,
                              EmailAddress = p.EmailAddress,
                              FirstName = p.FirstName,
                              LastName = p.LastName,
                              Gender = g.Gender1,
                              HasCar = p.HasCar,
                              ApartmentId = a.Apartmentguid.ToString(),
                              Address = new AddressDAO
                              {
                                  Address1 = add.Address1,
                                  Address2 = add.Address2,
                                  ApartmentNumber = add.ApartmentNumber,
                                  City = add.City,
                                  State = add.State,
                                  ZipCode = add.Zip
                              }
                          });

            return output.ToList ();
        }

        /// <summary>
        /// Returns a single Person by their email address.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet ("{id}")]
        [ActionName ("GetByEmail")]
        public PersonDAO GetByEmail(string id)
        {
            var person = _Context.Person;
            var gender = _Context.Gender;
            var address = _Context.Address;
            var apartment = _Context.Apartment;

            var list = (from p in person
                        join g in gender on p.GenderId equals g.GenderId
                        join add in address on p.AddressId equals add.AddressId
                        join a in apartment on add.AddressId equals a.AddressId
                        where p.EmailAddress == id
                        select new PersonDAO
                        {
                            PersonId = p.Personguid.ToString (),
                            ArrivalDate = p.ArrivalDate,
                            EmailAddress = p.EmailAddress,
                            FirstName = p.FirstName,
                            LastName = p.LastName,
                            Gender = g.Gender1,
                            HasCar = p.HasCar,
                            ApartmentId = a.Apartmentguid.ToString(),
                            Address = new AddressDAO
                            {
                                Address1 = add.Address1,
                                Address2 = add.Address2,
                                ApartmentNumber = add.ApartmentNumber,
                                City = add.City,
                                State = add.State,
                                ZipCode = add.Zip
                            }
                        });

            var output = new PersonDAO ();

            if (list.ToList ().Count > 0)
            {
                output = list.ToList ()[0];
            }

            return output;
        }


        /// <summary>
        /// Returns a single Person by their Guid.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet ("{id}")]
        [ActionName ("GetByGuid")]
        public PersonDAO GetByGuid(string id)
        {
            var person = _Context.Person;
            var gender = _Context.Gender;
            var address = _Context.Address;
            var apartment = _Context.Apartment;

            var list = (from p in person
                        join g in gender on p.GenderId equals g.GenderId
                        join add in address on p.AddressId equals add.AddressId
                        join a in apartment on add.AddressId equals a.AddressId
                        where p.Personguid.ToString() == id
                        select new PersonDAO
                        {
                            PersonId = p.Personguid.ToString (),
                            ArrivalDate = p.ArrivalDate,
                            EmailAddress = p.EmailAddress,
                            FirstName = p.FirstName,
                            LastName = p.LastName,
                            Gender = g.Gender1,
                            HasCar = p.HasCar,
                            ApartmentId = a.Apartmentguid.ToString (),
                            Address = new AddressDAO
                            {
                                Address1 = add.Address1,
                                Address2 = add.Address2,
                                ApartmentNumber = add.ApartmentNumber,
                                City = add.City,
                                State = add.State,
                                ZipCode = add.Zip
                            }
                        });

            var output = new PersonDAO ();

            if (list.ToList ().Count > 0)
            {
                output = list.ToList ()[0];
            }

            return output;
        }

        /// <summary>
        /// Returns a list of People by the Guid of the apartment they reside at.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet ("{id}")]
        [ActionName ("GetByApartment")]
        public List<PersonDAO> GetByApartment(string id)
        {
            var person = _Context.Person;
            var gender = _Context.Gender;
            var address = _Context.Address;
            var apartment = _Context.Apartment;

            var list = (from p in person
                        join g in gender on p.GenderId equals g.GenderId
                        join add in address on p.AddressId equals add.AddressId
                        join a in apartment on add.AddressId equals a.AddressId
                        where a.Apartmentguid.ToString() == id
                        select new PersonDAO
                        {
                            PersonId = p.Personguid.ToString (),
                            ArrivalDate = p.ArrivalDate,
                            EmailAddress = p.EmailAddress,
                            FirstName = p.FirstName,
                            LastName = p.LastName,
                            Gender = g.Gender1,
                            HasCar = p.HasCar,
                            ApartmentId = a.Apartmentguid.ToString (),
                            Address = new AddressDAO
                            {
                                Address1 = add.Address1,
                                Address2 = add.Address2,
                                ApartmentNumber = add.ApartmentNumber,
                                City = add.City,
                                State = add.State,
                                ZipCode = add.Zip
                            }
                        });

            return list.ToList();
        }

        /// <summary>
        /// Adds a new Person to the database.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Post([FromBody]PersonDAO value)
        {
            var outcome = false;

            if (value.FirstName != null)
            {
                outcome = true;
            }

            return outcome;
        }
    }
}
