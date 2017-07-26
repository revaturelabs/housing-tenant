﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HousingTenant.Data.Service.Models;
using HousingTenant.Data.Service.Interfaces;
using HousingTenant.Data.Service.Factory;
using HousingTenant.Data.Library.AzModels;
using HousingTenant.Data.Library.DataModels;


namespace HousingTenant.Data.Service.Controllers
{
    [Route("api/[controller]")]
    public class RequestController : Controller
    {
        //private IBroker<RequestDAO> broker;
        private List<RequestDAO> _List;
        private HousingTenantDBContext _Context;

        public RequestController(HousingTenantDBContext context)
        {
            _Context = context;
            //broker = new BrokerFactory<RequestDAO, Request> ().Create (context);
            var req = _Context.Request;
            var reqType = _Context.RequestType;
            var supReq = _Context.SupplyRequest;
            var supType = _Context.SupplyType;
            var Person = _Context.Person;
            var status = _Context.Status;
            var gender = _Context.Gender;
            var apart = _Context.Apartment;
            var address = _Context.Address;

            var main = from r in req
                       join rt in reqType on r.RequestTypeId equals rt.RequestTypeId
                       join stat in status on r.StatusId equals stat.StatusId
                       join p in Person on r.Initiator equals p.PersonId
                       join g in gender on p.GenderId equals g.GenderId
                       join add in address on p.AddressId equals add.AddressId
                       join a in apart on add.AddressId equals a.AddressId
                       select new RequestDAO
                       {
                           RequestId = r.Requestguid.ToString(),
                           Type = rt.RequestType1,
                           Urgent = r.IsUrgent,
                           DateModified = r.DateSubmitted,
                           DateSubmitted = r.DateSubmitted,
                           Initiator = new PersonDAO { PersonId = p.Personguid.ToString(),
                               ArrivalDate = p.ArrivalDate,
                               EmailAddress = p.EmailAddress,
                               FirstName = p.FirstName,
                               Gender = g.Gender1,
                               HasCar = p.HasCar,
                               LastName = p.LastName,
                               Address = new AddressDAO {
                                   Address1 = add.Address1,
                                   Address2 = add.Address2,
                                   ApartmentNumber = add.ApartmentNumber,
                                   City = add.City,
                                   ZipCode = add.Zip,
                                   State = add.State
                               }
                           },
                           Status = stat.Status1,
                           Description = r.Description,
                           RequestItems = (from r2 in req
                                           join sr in supReq on r2.RequestId equals sr.RequestId
                                           join st in supType on sr.SupplyTypeId equals st.SupplyTypeId
                                           where r.Requestguid == r2.Requestguid
                                           select st.Supply).ToList (),
                           ApartmentId = a.Apartmentguid.ToString()
                       };

            _List = main.ToList ();


            for (var i = 0; i < _List.Count; i++)
            {
                if (_List[i].Type == "Complaint")
                {
                    _List[i].Accused =
                     (from r in req
                      join p in Person on r.PersonIdAccused equals p.PersonId
                      join g in gender on p.GenderId equals g.GenderId
                      join add in address on p.AddressId equals add.AddressId
                      where r.Requestguid.ToString() == _List[i].RequestId
                      select new PersonDAO
                      {
                          PersonId = p.Personguid.ToString (),
                          ArrivalDate = p.ArrivalDate,
                          EmailAddress = p.EmailAddress,
                          FirstName = p.FirstName,
                          Gender = g.Gender1,
                          HasCar = p.HasCar,
                          LastName = p.LastName,
                          Address = new AddressDAO
                          {
                              Address1 = add.Address1,
                              Address2 = add.Address2,
                              ApartmentNumber = add.ApartmentNumber,
                              City = add.City,
                              ZipCode = add.Zip,
                              State = add.State
                          }
                      }).ToList ()[0];
                }
    }
}

        [HttpGet]
        public List<RequestDAO> Get()
        {
            return _List;
        }

        [HttpGet ("{id}")]
        public List<RequestDAO> Get(string id)
        {
            var output = (from l in _List where l.ApartmentId == id select l).ToList ();
            return output;
        }

        [HttpPost]
        public bool Post([FromBody]RequestDAO value)
        {
            return true;
        }
    }
}
