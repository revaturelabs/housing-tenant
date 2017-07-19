using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Library.Models
{
    public class SupplyRequest : ARequest
    {
        private List<string> _RequestItems;
        public List<string> RequestItems {
           get { return _RequestItems; }
           set { _RequestItems = value; }
        }
        
        public SupplyRequest()
        {
            _RequestItems = new List<string>();
        }
        /// <summary>
        /// Compares two Supply request by checking the address of the initiator
        /// date of the request and the status. If they are all equal then the
        /// requests are "deemed" equal and another Supply request from this 
        /// address will not be allowed on that day unless the status change to
        /// completed or rejected
        /// </summary>
        /// <param name="obj">the object to compare against this request</param>
        /// <returns>true if initiator address, date submitted and status are equal,
        /// false otherwise</returns>
        public override bool Equals(object obj)
        {
            if(obj != null && obj.GetType() == GetType())
            {
                var newSupplyRequest = obj as SupplyRequest;

                return newSupplyRequest.Initiator.Address.Equals(Initiator.Address) &&
                   newSupplyRequest.DateSubmitted.Equals(DateSubmitted) &&
                   (newSupplyRequest.Status == StatusEnum.PENDING || newSupplyRequest.Status == StatusEnum.INWORK) &&
                   (Status == StatusEnum.PENDING || Status == StatusEnum.INWORK);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Initiator.GetHashCode() + DateSubmitted.GetHashCode() + Status.GetHashCode();
        }

        public override bool IsValid()
        {
            return _RequestItems.Count > 0;
        }

        public override string ToString()
        {
            string items = "";
            var length = RequestItems.Count;
         
            for(var i = 0; i < length; i++)
            {
               items += (i + 1) == length ? RequestItems[i] : RequestItems[i] + ", ";
            }
            return string.Format("{0} Supplies: {1}",base.ToString(),items);
        }
   }
}
