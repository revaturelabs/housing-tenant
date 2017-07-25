﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HousingTenant.Data.Service.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HousingTenant.Data.Service.Controllers
{
    [Route("api/[controller]")]
    public class ApartmentController : Controller
    {
        private List<ApartmentDAO> list = new List<ApartmentDAO> ();
        
        public ApartmentController()
        {
            list.Add (new ApartmentDAO { Address = new AddressDAO (), ApartmentId = "0", Bathrooms = 2, Beds = 3 });
            list.Add (new ApartmentDAO { Address = new AddressDAO (), ApartmentId = "1", Bathrooms = 2, Beds = 3 });
            list.Add (new ApartmentDAO { Address = new AddressDAO (), ApartmentId = "2", Bathrooms = 2, Beds = 3 });
        }

        // GET: api/values
        [HttpGet]
        public List<ApartmentDAO> Get()
        {
            return list;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public List<ApartmentDAO> Get(string id)
        {
            return (from v in list where v.ApartmentId == id select v).ToList();
        }

        // POST api/values
        [HttpPost]
        public bool Post([FromBody]ApartmentDAO value)
        {
            return value.Address != null;
        }
    }
}