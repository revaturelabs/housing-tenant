using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Library.Models
{
    public class MaintenanceRequest : ARequest
    {

        public override int CompareTo(ARequest other)
        {
            if (other != null && other.GetType() == GetType())
            {
                var otherRequest = other as MaintenanceRequest;
                var thisRequestString = string.Format("{0} {1} {2}",
                   Initiator.Address, Description, (Status == StatusEnum.INWORK || Status == StatusEnum.PENDING ? StatusEnum.PENDING : StatusEnum.COMPLETED));
                var otherRequestString = string.Format("{0} {1} {2}",
                   otherRequest.Initiator.Address, otherRequest.Description, (otherRequest.Status == StatusEnum.INWORK || otherRequest.Status == StatusEnum.PENDING ? StatusEnum.PENDING : StatusEnum.COMPLETED));

                return thisRequestString.CompareTo(otherRequestString);
            }
            return -1;
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
