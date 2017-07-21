using HousingTenant.Business.Library;
using HousingTenant.Business.Library.Models;
using HousingTenant.Business.Service.Models;
using System.Collections.Generic;

namespace HousingTenant.Business.Service.Mappers
{
    public class BusinessServiceMapper
    {

        public ARequest MapToARequest(RequestDTO requestDto)
        {
            ARequest request = null;
            if (requestDto != null)
            {
                switch (requestDto.Type)
                {
                   case 0:
                      request = new ComplaintRequest
                      {
                          Accused = requestDto.Accused
                      };
                      break;
                   case 1:
                      request = new MaintenanceRequest ();
                      break;
                   case 2:
                      request = new MoveRequest
                      {
                          RequestedApartmentAddress = requestDto.RequestedApartmentAddress
                      };
                      break;
                   case 3:
                      request = new SupplyRequest
                      {
                          RequestItems = requestDto.RequestItems
                      };
                      break;
                }
                request.RequestId = requestDto.RequestId;
                request.Initiator = requestDto.Initiator;
                request.Description = requestDto.Description;
                request.DateSubmitted = requestDto.DateSubmitted;
                request.DateModified = requestDto.DateModified;
                request.Status = requestDto.Status;
                request.Urgent = requestDto.Urgent;
            }
            return request;
        }

        public List<ARequest> MapToARequestList(List<RequestDTO> dtorequests)
        {
            var requests = new List<ARequest>();
            foreach (var r in dtorequests)
            {
                requests.Add(MapToARequest(r));
            }
            return requests;
        }

        public List<IPerson> MapToIPersonList(List<Person> persons)
        {
            var ipersons = new List<IPerson>();
            foreach(var p in persons)
            {
                ipersons.Add(p);
            }
            return ipersons;
        }
    }
}
