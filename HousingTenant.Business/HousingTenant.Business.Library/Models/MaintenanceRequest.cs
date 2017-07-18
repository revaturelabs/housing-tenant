using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Library.Models
{
    public class MaintenanceRequest : ARequest
    {
        public string Description { get; set; }

        /// <summary>
        /// Compares two MaintenanceRequest for equality using the address 
        /// of the person that submitted the Maintenance request, the
        /// description text, and statuses of each request. 
        /// </summary>
        /// <param name="obj">
        /// The maintenance request that this request is being compared
        /// </param>
        /// <returns>
        /// True if the request originated at the same address, reqeust text of 
        /// both request are the same and their statuses are either pending or in-work,
        /// false otherwise
        /// </returns>
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

        /// <summary>
        /// Generage a unique number for this object
        /// </summary>
        /// <returns>
        /// A number that represent this class
        /// </returns>
        public override int GetHashCode()
        {
            return Initiator.GetHashCode() + 
               Description.GetHashCode() + 
               Status.GetHashCode();
        }

         /// <summary>
         /// Generate a string representation of this class
         /// </summary>
         /// <returns>
         /// String representation of this class instance
         /// </returns>
         public override string ToString()
         {
             return string.Format("{0}\n Description: {1} Status: {2}",
                base.ToString(), Description, Status);
         }
   }
}
