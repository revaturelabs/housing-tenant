using HousingTenant.Business.Library;
using HousingTenant.Business.Library.Models;
using HousingTenant.Business.Service.Models;
using System.Collections.Generic;

namespace HousingTenant.Business.Service.Mappers
{
    public class BusinessServiceMapper
   {
      static readonly string[] REQUEST_TYPES = { "COMPLAINT", "MAINTENANCE", "MOVE", "SUPPLIES" };

      public IApartment MapToIApartment(ApartmentDTO apartmentdto)
      {
         return new Apartment
         {
            Address = apartmentdto.Address,
            ApartmentId = apartmentdto.ApartmentId,
            Bathrooms = apartmentdto.Bathrooms,
            Beds = apartmentdto.Beds,
            ComplexName = apartmentdto.ComplexName,
            Persons = MapToIPersonList(apartmentdto.Persons),
            Requests = MapToARequestList(apartmentdto.Requests)
         };
      }

      public ApartmentDTO MapToApartmentDTO(IApartment iapartment)
      {
         var apartment = iapartment as Apartment;
         return new ApartmentDTO
         {
            Address = apartment.Address,
            ApartmentId = apartment.ApartmentId,
            Bathrooms = apartment.Bathrooms,
            Beds = apartment.Beds,
            ComplexName = apartment.ComplexName,
            Persons = MapToPersonDTOList(apartment.Persons),
            Requests = MapToRequestDTOList(apartment.Requests)
         };
      }

      public List<IApartment> MapToIApartmentList(List<ApartmentDTO> ApartmentDTOs)
      {
         var ApartmentList = new List<IApartment>();
         if (ApartmentDTOs != null)
         {
            foreach (var apt in ApartmentDTOs)
            {
               ApartmentList.Add(MapToIApartment(apt));
            }
         }
         return ApartmentList;
      }

      public List<ApartmentDTO> MapToApartmentDTOList(List<IApartment> Apartments)
      {
         var ApartmentDTOList = new List<ApartmentDTO>();
         if (Apartments != null)
         {
            foreach (var apt in Apartments)
            {
               ApartmentDTOList.Add(MapToApartmentDTO(apt));
            }
         }
         return ApartmentDTOList;
      }

      public IPerson MapToIPerson(PersonDTO person)
      {
         return new Person
         {
            Address = person.Address,
            ArrivalDate = person.ArrivalDate,
            EmailAddress = person.EmailAddress,
            FirstName = person.FirstName,
            Gender = person.Gender,
            HasCar = person.HasCar,
            LastName = person.LastName,
            PersonId = person.PersonDTOId,
            PhoneNumber = person.PhoneNumber,
            ApartmentId = person.ApartmentId
         };
      }

      public List<IPerson> MapToIPersonList(List<PersonDTO> PersonDTOs)
      {
         var PersonList = new List<IPerson>();
         if (PersonDTOs != null)
         {
            foreach (var per in PersonDTOs)
            {
               PersonList.Add(MapToIPerson(per));
            }
         }
         return PersonList;
      }

      public PersonDTO MapToPersonDTO(IPerson iperson)
      {
         if (iperson != null)
         {
            var person = iperson as Person;
            return new PersonDTO
            {
               Address = person.Address,
               ArrivalDate = person.ArrivalDate,
               EmailAddress = person.EmailAddress,
               FirstName = person.FirstName,
               LastName = person.LastName,
               Gender = person.Gender,
               HasCar = person.HasCar,
               PersonDTOId = person.PersonId,
               PhoneNumber = person.PhoneNumber,
               ApartmentId = person.ApartmentId
            };
         }
         return new PersonDTO();
      }

      public List<PersonDTO> MapToPersonDTOList(List<IPerson> persons)
      {
         var PersonDTOList = new List<PersonDTO>();
         if (persons != null)
         {
            foreach (var p in persons)
            {
               var pers = p as Person;
               PersonDTOList.Add(MapToPersonDTO(pers));
            }
         }
         return PersonDTOList;
      }

      public ARequest MapToARequest(RequestDTO requestDto)
      {
         ARequest request = null;
         if (requestDto != null)
         {
            switch (requestDto.Type)
            {
               case "COMPLAINT":
                  request = new ComplaintRequest
                  {
                     Accused = requestDto.Accused
                  };
                  break;
               case "MAINTENANCE":
                  request = new MaintenanceRequest();
                  break;
               case "MOVE":
                  request = new MoveRequest
                  {
                     RequestedApartmentAddress = requestDto.RequestedApartmentAddress
                  };
                  break;
               case "SUPPLIES":
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
               requestdto.Type = "COMPLAINT";
               requestdto.Accused = (Person)((ComplaintRequest)arequest).Accused;
            }
            else if (arequest is MaintenanceRequest)
            {
               requestdto.Type = "MAINTENANCE";
            }
            else if (arequest is MoveRequest)
            {
               requestdto.Type = "MOVE";
               requestdto.RequestedApartmentAddress = ((MoveRequest)arequest).RequestedApartmentAddress;
            }
            else
            {
               requestdto.Type = "SUPPLIES";
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
   }
}
