using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Library.Models
{
    public class ComplaintRequest : ARequest
    {
        public IPerson Accused { get; set; }
        
        public override int CompareTo(ARequest other)
        {
            if(other != null && other.GetType() == GetType())
            {
                var otherRequest = other as ComplaintRequest;
                var thisRequestString = string.Format("{0} {1} {2} {3}",
                   Initiator, Accused,Description,(Status == StatusEnum.INWORK || Status == StatusEnum.PENDING ? StatusEnum.PENDING : StatusEnum.COMPLETED));
                var otherRequestString = string.Format("{0} {1} {2} {3}",
                   otherRequest.Initiator, otherRequest.Accused, otherRequest.Description, (otherRequest.Status == StatusEnum.INWORK || otherRequest.Status == StatusEnum.PENDING ? StatusEnum.PENDING : StatusEnum.COMPLETED));
                
                return thisRequestString.CompareTo(otherRequestString);
            }
            return -1;
        }

        public override bool IsValid()
        {
            return Accused != null && Description != null;
        }
      
        public override string ToString()
        {
            return string.Format("{0}\nAccused: {1} Complaint: {2}", 
               base.ToString(), Accused.GetFullName(), Description);
        }
   }
}
