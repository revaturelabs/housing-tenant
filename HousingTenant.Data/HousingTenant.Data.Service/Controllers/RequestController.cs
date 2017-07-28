using System;
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
        /// <summary>
        /// private field containing the list of all the requests in the database.
        /// </summary>
        private List<RequestDAO> _List;

        /// <summary>
        /// private field containing the DBContext of the database being used.
        /// </summary>
        private HousingTenantDBContext _Context;

        /// <summary>
        /// Updates _Context to represent the current state of the database being used.  
        /// Also updates _List to include all requests in the database.
        /// </summary>
        /// <param name="context"></param>
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
                if (_List[i].Type == "ComplaintRequest")
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

        /// <summary>
        /// Returns all the Requests in the database.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<RequestDAO> Get()
        {
            return _List;
        }

        /// <summary>
        /// Returns a list of Request by the Apartment Guid there are asscociated with.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet ("{id}")]
        public List<RequestDAO> Get(string id)
        {
            var output = (from l in _List where l.ApartmentId == id select l).ToList ();
            return output;
        }

        /// <summary>
        /// Adds a new Request to database.
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Post([FromBody]RequestDAO value)
        {
            var req = _Context.Request;
            var reqType = _Context.RequestType;
            var supReq = _Context.SupplyRequest;
            var supType = _Context.SupplyType;
            var Person = _Context.Person;
            var status = _Context.Status;
            var apart = _Context.Apartment;

            var newRequest = new Request {
                Active = true,
                DateModified = DateTime.Now,
                DateSubmitted = DateTime.Now,
                Description = value.Description,
                Requestguid = new Guid(),
                IsUrgent = value.Urgent,
                ApartmentId = (from a in apart
                               where a.Apartmentguid.ToString() == value.ApartmentId
                               select a.ApartmentId).ToList()[0],
                Initiator = (from p in Person
                             where p.Personguid.ToString() == value.Initiator.PersonId
                             select p.PersonId).ToList()[0],
                RequestTypeId = (from rt in reqType
                                 where rt.RequestType1 == value.Type
                                 select rt.RequestTypeId).ToList()[0],
                StatusId = (from s in status
                            where s.Status1 == value.Status
                            select s.StatusId).ToList()[0]
            };

            if(value.Type == "ComplaintRequest")
            {
                newRequest.PersonIdAccused = (from p in Person
                                              where p.Personguid == new Guid(value.Accused.PersonId)
                                              select p.PersonId).ToList()[0];
            }else if(value.Type == "SupplyRequest")
            {
                var temp = new List<SupplyRequest> ();

                foreach(var item in value.RequestItems)
                {
                    temp.Add (new SupplyRequest { SupplyTypeId = (from st in supType
                                                                  where st.Supply == item
                                                                  select st.SupplyTypeId).ToList()[0],
                                                  Active = true,
                                                  
                                                 });
                }

                newRequest.SupplyRequest = temp;
            }

            _Context.Request.Add (newRequest);
            _Context.SaveChanges ();

        }
    }
}
