using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousingTenant.Data.Service.Interfaces;
using HousingTenant.Data.Service.Models;

namespace HousingTenant.Data.Service.Brokers
{
    public class RequestBroker : IBroker<RequestDAO>
    {
        public bool Create(RequestDAO obj)
        {
            throw new NotImplementedException ();
        }

        public bool Delete(RequestDAO obj)
        {
            throw new NotImplementedException ();
        }

        public List<RequestDAO> Get()
        {
            throw new NotImplementedException ();
        }

        public bool Update(RequestDAO obj)
        {
            throw new NotImplementedException ();
        }
    }
}
