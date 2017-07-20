using HousingTenant.Business.Library.Models;
using HousingTenant.Business.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                          Initiator = requestDto.Initiator,
                          Accused = requestDto.Accused,
                          Complaint = requestDto.Complaint,
                          DateSubmitted = requestDto.DateSubmitted,
                          DateModified = requestDto.DateModified,
                          Status = requestDto.Status,
                          Urgent = requestDto.Urgent
                      };
                      break;
                   case 1:
                      request = new MaintenanceRequest
                      {
                          Initiator = requestDto.Initiator,
                          Description = requestDto.Description,
                          DateSubmitted = requestDto.DateSubmitted,
                          DateModified = requestDto.DateModified,
                          Status = requestDto.Status,
                          Urgent = requestDto.Urgent
                      };
                      break;
                   case 2:
                      request = new MoveRequest
                      {
                          Initiator = requestDto.Initiator,
                          RequestedApartmentAddress = requestDto.RequestedApartmentAddress,
                          Reason = requestDto.Reason,
                          DateSubmitted = requestDto.DateSubmitted,
                          DateModified = requestDto.DateModified,
                          Status = requestDto.Status,
                          Urgent = requestDto.Urgent
                      };
                      break;
                   case 3:
                      request = new SupplyRequest
                      {
                          Initiator = requestDto.Initiator,
                          RequestItems = requestDto.RequestItems,
                          DateSubmitted = requestDto.DateSubmitted,
                          DateModified = requestDto.DateModified,
                          Status = requestDto.Status,
                          Urgent = requestDto.Urgent
                      };
                      break;
                }
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
    }
}
