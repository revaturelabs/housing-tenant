using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Library.Models
{
    public class MaintenanceRequest : ARequest
    {
        public override bool Equals(object obj)
        {
            if(obj != null && obj.GetType() == GetType())
            {
                var newRequest = obj as MaintenanceRequest;

            return newRequest.Initiator.Address.Equals(Initiator.Address) &&
               newRequest.Description.ToLower().Equals(Description.ToLower()) &&
                   (newRequest.Status == StatusEnum.PENDING || newRequest.Status == StatusEnum.INWORK) &&
                   (Status == StatusEnum.PENDING || Status == StatusEnum.INWORK);
            }
            return false;
        }
      
        public override int GetHashCode()
        {
            return Initiator.GetHashCode() + 
               Description.GetHashCode() + 
               Status.GetHashCode();
        }

        public override bool IsValid()
        {
            return Description != null;
        }
      
        public override string ToString()
        {
            return string.Format("{0}\n Description: {1} Status: {2}",
               base.ToString(), Description, Status);
        }
   }
}
