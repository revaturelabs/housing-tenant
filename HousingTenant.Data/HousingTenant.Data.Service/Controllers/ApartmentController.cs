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
    public class ApartmentController : Controller
    {
        private HousingTenantDBContext _Context;

        public ApartmentController(HousingTenantDBContext context)
        {
            _Context = context;
        }

        // GET: api/values
        [HttpGet]
        public List<ApartmentDAO> Get()
        {
            var apartment = _Context.Apartment;
            var address = _Context.Address;

            var list = (from ap in apartment
                        join add in address on ap.AddressId equals add.AddressId
                        select new ApartmentDAO {
                        Bathrooms = ap.NumberofBathroom,
                        Beds = ap.NumberofBeds,
                        ApartmentId = ap.Apartmentguid.ToString(),
                        Address = new AddressDAO
                        {
                            Address1 = add.Address1,
                            Address2 = add.Address2,
                            City = add.City,
                            State = add.State,
                            ApartmentNumber = add.ApartmentNumber,
                            ZipCode = add.Zip
                        }
                        });
            return list.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ApartmentDAO Get(string id)
        {
            var apartment = _Context.Apartment;
            var address = _Context.Address;

            var list = (from ap in apartment
                        join add in address on ap.AddressId equals add.AddressId
                        where ap.Apartmentguid.ToString() == id
                        select new ApartmentDAO
                        {
                            Bathrooms = ap.NumberofBathroom,
                            Beds = ap.NumberofBeds,
                            ApartmentId = ap.Apartmentguid.ToString (),
                            Address = new AddressDAO
                            {
                                Address1 = add.Address1,
                                Address2 = add.Address2,
                                City = add.City,
                                State = add.State,
                                ApartmentNumber = add.ApartmentNumber,
                                ZipCode = add.Zip
                            }
                        });

            var output = new ApartmentDAO();

            if(list.ToList().Count > 0)
            {
                output = list.ToList ()[0];
            }

            return output;
        }

        // POST api/values
        [HttpPost]
        public bool Post([FromBody]ApartmentDAO value)
        {
            return value.Address.Address1 != null;
        }
    }
}
