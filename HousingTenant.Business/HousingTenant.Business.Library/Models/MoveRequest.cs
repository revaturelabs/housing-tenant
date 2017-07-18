using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Library.Models
{
    public class MoveRequest : ARequest
    {
        public string Reason { get; set; }
        public Address RequestedApartmentAddress { get; set; }

        /// <summary>
        /// Compares two Move Request for equality using the initiator
        /// and the apartment address requested
        /// </summary>
        /// <param name="obj">The object this request is being compared with</param>
        /// <returns>true if the initiators are the same and the address is the same,
        /// false otherwise</returns>
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

        /// <summary>
        /// Generate a unique number for each instance of this object
        /// </summary>
        /// <returns>a unique number to this object instance</returns>
        public override int GetHashCode()
        {
            return Initiator.GetHashCode() + RequestedApartmentAddress.GetHashCode();
        }

        /// <summary>
        /// Generate a string representation of this class
        /// </summary>
        /// <returns>
        /// String representation of this class instance
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0}\nReason: {1}",
               base.ToString(), Reason);
        }
   }
}
