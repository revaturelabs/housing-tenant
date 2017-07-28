using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HousingTenant.Data.Service.Models;
using HousingTenant.Data.Library.AzModels;

namespace HousingTenant.Data.Service.Controllers
{
    [Route("api/[controller]")]
    public class ApartmentController : Controller
    {
        /// <summary>
        /// private field containing the DBContext of the database being used
        /// </summary>
        private HousingTenantDBContext _Context;

        /// <summary>
        /// Updates _Context to represent the current state of the database being used.
        /// </summary>
        /// <param name="context"></param>
        public ApartmentController(HousingTenantDBContext context)
        {
            _Context = context;
        }

        /// <summary>
        /// Returns all the apartments stored in the database.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Returns a single apartment that matches the given Guid value. 
        /// If there is no match a blank apartment object is returned instead.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Adds a new apartment to the database.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Post([FromBody]ApartmentDAO value)
        {
            return value.Address.Address1 != null;
        }
    }
}
