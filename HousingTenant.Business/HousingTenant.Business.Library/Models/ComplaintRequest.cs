using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Library.Models
{
    public class ComplaintRequest : ARequest
    {
        public IPerson Accused { get; set; }
      
        public override bool Equals(object obj)
        {
            if(obj != null && obj.GetType() == GetType())
            {
                var newComplaint = obj as ComplaintRequest;

                return newComplaint.Initiator.Equals(Initiator) &&
                   newComplaint.Accused.Equals(Accused) &&
                   newComplaint.Description.ToLower().Equals(Description.ToLower()) &&
                   (newComplaint.Status == StatusEnum.PENDING || newComplaint.Status == StatusEnum.INWORK) &&
                   (Status == StatusEnum.PENDING || Status == StatusEnum.INWORK);
            }
            return false;
        }
      
        public override int GetHashCode()
        {
            return Initiator.GetHashCode() + 
               Accused.GetHashCode() + 
               Description.GetHashCode() +
               Status.GetHashCode();
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
