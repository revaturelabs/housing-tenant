using HousingTenant.Business.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Library
{
   public class LibraryManager
   {

      public IApartment PackApartment(IApartment apartment, List<IPerson> tenants, List<ARequest> requests)
      {
         if (apartment == null)
         {
            return null;
         }

         foreach (var tenant in tenants)
         {
            apartment.AddTenant(tenant);
         }

         foreach (var request in requests)
         {
            apartment.AddRequest(request);
         }
         return apartment;
      }

      public IApartment ValidateApartment(IApartment apartment)
      {
         if (apartment != null)
         {
            return apartment.IsValid() ? apartment : null;
         }
         return null;
      }

      public ARequest ValidateRequest(ARequest request)
      {
         if (request != null)
         {
            return request.IsValid() ? request : null;
         }
         return null;
      }

      public IPerson ValidateTenant(IPerson tenant)
      {
         if (tenant != null)
            return tenant.IsValid() ? tenant : null;

         return null;
      }
   }
}
