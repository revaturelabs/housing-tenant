using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Library.Models
{
    public class MoveRequest : ARequest
    {
        public Address RequestedApartmentAddress { get; set; }
      
        public override bool Equals(object obj)
        {
            if(obj != null && obj.GetType() == GetType())
            {
                var newMoveRequest = obj as MoveRequest;

                return newMoveRequest.Initiator.Equals(Initiator) &&
                   newMoveRequest.RequestedApartmentAddress.Equals(RequestedApartmentAddress);
            }
             return false;
        }
      
        public override int GetHashCode()
        {
            return Initiator.GetHashCode() + RequestedApartmentAddress.GetHashCode();
        }

        public override bool IsValid()
        {
            return Description != null && RequestedApartmentAddress != null;
        }
      
        public override string ToString()
        {
            return string.Format("{0}\nReason: {1}",
               base.ToString(), Description);
        }
   }
}
