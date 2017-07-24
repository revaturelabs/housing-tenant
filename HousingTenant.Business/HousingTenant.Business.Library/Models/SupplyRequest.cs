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

        public override int CompareTo(ARequest other)
        {
            if (other != null && other.GetType() == GetType())
            {
                var otherRequest = other as SupplyRequest;
                var thisRequestString = string.Format("{0} {1} {2}",
                   Initiator.Address, DateSubmitted, (Status == StatusEnum.INWORK || Status == StatusEnum.PENDING ? StatusEnum.PENDING : StatusEnum.COMPLETED));
                var otherRequestString = string.Format("{0} {1} {2}",
                   otherRequest.Initiator.Address, DateSubmitted, (otherRequest.Status == StatusEnum.INWORK || otherRequest.Status == StatusEnum.PENDING ? StatusEnum.PENDING : StatusEnum.COMPLETED));

                return thisRequestString.CompareTo(otherRequestString);
            }
            return -1;
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
