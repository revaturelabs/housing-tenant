using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousingTenant.Business.Service.Interfaces;
using HousingTenant.Business.Library.Models;
using HousingTenant.Business.Service.Models;

namespace HousingTenant.Business.Service.Brokers
{
    public class RequestBroker : IBroker<ARequest,Apartment,RequestDTO>
    {
        public bool Create(RequestDTO obj)
        {
            throw new NotImplementedException ();
        }

        public bool Delete(ARequest obj)
        {
            throw new NotImplementedException ();
        }

        public List<ARequest> Get()
        {
            var list = new List<ARequest> ();

            list.Add (new MaintenanceRequest {Description = "Stuff Broke", Initiator = new Person { FirstName = "you", LastName = "there" }, DateSubmitted = DateTime.Now });
            list.Add (new SupplyRequest { Initiator = new Person { FirstName = "you", LastName = "there" } });
            list.Add (new ComplaintRequest ());

            return list;
        }

        public List<ARequest> Get(Apartment obj)
        {
            throw new NotImplementedException ();
        }

        public bool Update(ARequest obj)
        {
            throw new NotImplementedException ();
        }
    }
}
