using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HousingTenant.Data.Service.Models;
using HousingTenant.Data.Library.AzModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HousingTenant.Data.Service.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private List<RequestDAO> _List;
        private HousingTenantDBContext _Context;

        public PersonController(HousingTenantDBContext context)
        {
            _Context = context;
        }

        // GET: api/values
        [HttpGet]
        public List<PersonDAO> Get()
        {
            var person = _Context.Person;
            var gender = _Context.Gender;
            var address = _Context.Address;

            var output = (from p in person 
                          join g in gender on p.GenderId equals g.GenderId
                          join add in address on p.AddressId equals add.AddressId
                          select new PersonDAO
                          {
                              PersonId = p.Personguid.ToString(),
                              ArrivalDate = p.ArrivalDate,
                              EmailAddress = p.EmailAddress,
                              FirstName = p.FirstName,
                              LastName = p.LastName,
                              Gender = g.Gender1,
                              HasCar = p.HasCar,
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

        // GET api/values/5
        [HttpGet("{id}")]
        public PersonDAO Get(string id)
        {
            var person = _Context.Person;
            var gender = _Context.Gender;
            var address = _Context.Address;

            var list = (from p in person
                          join g in gender on p.GenderId equals g.GenderId
                          join add in address on p.AddressId equals add.AddressId
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

        // POST api/values
        [HttpPost]
        public bool Post([FromBody]PersonDAO value)
        {
            var outcome = false;

            if(value.FirstName != null)
            {
                outcome = true;
            }

            return outcome;
        }
    }
}
