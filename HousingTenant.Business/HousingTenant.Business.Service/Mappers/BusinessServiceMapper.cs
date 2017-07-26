using HousingTenant.Business.Library;
using HousingTenant.Business.Library.Models;
using HousingTenant.Business.Service.Models;
using System.Collections.Generic;

namespace HousingTenant.Business.Service.Mappers
{
    public class BusinessServiceMapper
    {

        public ApartmentDTO MapToApartmentDTO(Apartment apartment)
        {
            return new ApartmentDTO { Address = apartment.Address,
               ApartmentId = apartment.ApartmentId,
               Bathrooms = apartment.Bathrooms,
               Beds = apartment.Beds,
               ComplexName = apartment.ComplexName,
               Persons = MapToPersonDTOList(apartment.Persons),
               Requests = MapToRequestDTOList(apartment.Requests)};
        }

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
                     request = new MaintenanceRequest();
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

         public RequestDTO MapToRequestDTO(ARequest arequest)
         {
            RequestDTO requestdto = new RequestDTO();
            if (arequest != null)
            {
               if (arequest is ComplaintRequest)
               {
                  requestdto.Type = 0;
                  requestdto.Accused = (Person)((ComplaintRequest)arequest).Accused;
               }
               else if (arequest is MaintenanceRequest)
               {
                  requestdto.Type = 1;
               }
               else if (arequest is MoveRequest)
               {
                  requestdto.Type = 2;
                  requestdto.RequestedApartmentAddress = ((MoveRequest)arequest).RequestedApartmentAddress;
               }
               else
               {
                  requestdto.Type = 3;
                  requestdto.RequestItems = ((SupplyRequest)arequest).RequestItems;
               }
               requestdto.ApartmentId = arequest.ApartmentId;
               requestdto.Initiator = (Person)arequest.Initiator;
               requestdto.Description = arequest.Description;
               requestdto.DateModified = arequest.DateModified;
               requestdto.DateSubmitted = arequest.DateSubmitted;
               requestdto.RequestId = arequest.RequestId;
               requestdto.Status = arequest.Status;
               requestdto.Urgent = arequest.Urgent;
            }

            return requestdto;
         }

         public List<RequestDTO> MapToRequestDTOList(List<ARequest> requestList)
         {
            var RequestDTOList = new List<RequestDTO>();
            if (requestList != null)
            {
               foreach (var request in requestList)
               {
                  RequestDTOList.Add(MapToRequestDTO(request));
               }
            }

            return RequestDTOList;
         }

         public List<ARequest> MapToARequestList(List<RequestDTO> dtorequests)
         {
            var requests = new List<ARequest>();
            if (dtorequests != null)
            {
               foreach (var r in dtorequests)
               {
                  requests.Add(MapToARequest(r));
               }
            }
            return requests;
         }

         public List<IPerson> MapToIPersonList(List<Person> persons)
      {
         var ipersons = new List<IPerson>();
         if (persons != null)
         {
            foreach (var p in persons)
            {
               ipersons.Add(p);
            }
         }
         return ipersons;
      }

        public PersonDTO MapToPersonDTO(Person person)
        {
            if(person == null)
            {
               return new PersonDTO();
            }

            return new PersonDTO
            {
                Address = person.Address,
                ArrivalDate = person.ArrivalDate,
                EmailAddress = person.EmailAddress,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Gender = (int)person.Gender,
                HasCar = person.HasCar,
                PersonDTOId = person.PersonId,
                PhoneNumber = person.PhoneNumber,
            };
        }

      public List<PersonDTO> MapToPersonDTOList(List<IPerson> persons)
      {
         var PersonDTOs =  new List<PersonDTO>();
         foreach(var p in persons)
         {
            var pers = p as Person;
            PersonDTOs.Add(MapToPersonDTO(pers));
         }
         return PersonDTOs;
      }
   }
}
