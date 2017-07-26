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
            var main = from r in req
                       join rt in reqType on r.RequestTypeId equals rt.RequestTypeId
                       join stat in status on r.StatusId equals stat.StatusId
                       join p in Person on r.Initiator equals p.PersonId
                       select new RequestDAO
                       {
                           Requestguid = r.Requestguid,
                           RequestType = rt.RequestType1,
                           IsUrgent = r.IsUrgent,
                           DateModified = r.DateModified,
                           DateSubmitted = r.DateSubmitted,
                           Initiator = p.Personguid,
                           PersonIdAccused = (from p2 in Person
                                              where p2.PersonId == r.PersonIdAccused
                                              select p2.Personguid).ToList(),
                           Status = stat.Status1,
                           Description = r.Description,
                           RequestItems = (from r2 in req
                                           join sr in supReq on r2.RequestId equals sr.RequestId
                                           join st in supType on sr.SupplyTypeId equals st.SupplyTypeId
                                           where r.Requestguid == r2.Requestguid
                                           select st.Supply).ToList ()
                       };
            _List = main.ToList ();
        }

        [HttpGet]
        public List<RequestDAO> Get()
        {
            return _List;
        }

        [HttpGet ("{id}")]
        public RequestDAO Get(Guid id)
        {
            var output = (from l in _List where l.Requestguid == id select l).ToList ();
            return output[0];
        }

        [HttpPost]
        public bool Post([FromBody]RequestDAO value)
        {
            return true;
        }
    }
}
