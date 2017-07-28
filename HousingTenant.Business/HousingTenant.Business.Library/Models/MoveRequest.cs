using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Library.Models
{
    public class MoveRequest : ARequest
    {
        public Address RequestedApartmentAddress { get; set; }

        public override int CompareTo(ARequest other)
        {
            if (other != null && other.GetType() == GetType())
            {
                var otherRequest = other as MoveRequest;
                var thisRequestString = string.Format("{0} {1} {2} {3}",
                   Initiator, Description, RequestedApartmentAddress, (Status == "Hold" || Status == "Pending" ? "Pending" : "Completed"));
                var otherRequestString = string.Format("{0} {1} {2} {3}",
                   otherRequest.Initiator, otherRequest.Description, otherRequest.RequestedApartmentAddress, (otherRequest.Status == "Hold" || otherRequest.Status == "Pending" ? "Pending" : "Completed"));

                return thisRequestString.CompareTo(otherRequestString);
            }
            return -1;
        }

        public override bool IsValid()
        {
            return Initiator != null && Description != null && RequestedApartmentAddress != null;
        }
      
        public override string ToString()
        {
            return string.Format("{0}\nReason: {1}",
               base.ToString(), Description);
        }
   }
}
