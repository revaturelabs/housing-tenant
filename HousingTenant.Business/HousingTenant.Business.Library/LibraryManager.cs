using HousingTenant.Business.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Library
{

   public class LibraryManager
   {
      // Last minute work-around due to changes in the data layer to avoid conflict between UI and data layer -- temp
      readonly string[] requestItems = { "hand soap", "toilet paper", "paper towels", "dish soap", "trash bags", "dishwasher detergent", "sponges", "light bulbs" };

      public List<string> NormalizeRequestList(List<string> items)
      {

         if(items != null)
         {
            var normalizedList = new List<string>();
            foreach(var item in items)
            {
               foreach(var s in requestItems)
               {
                  var lower = item.ToLower();
                  if(s == lower)
                  {
                     normalizedList.Add(lower);
                     break;
                  }
               }
            }
            return normalizedList;
         }
         return null;
      }

      public IApartment PackApartment(IApartment apartment, List<IPerson> tenants, List<ARequest> requests)
      {
         if (apartment != null)
         {
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
         return new Apartment();
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
