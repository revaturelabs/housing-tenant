using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Library.Models
{
    public class ComplaintRequest : ARequest
    {
        public IPerson Accused { get; set; }
        public string Complaint { get; set; }

        /// <summary>
        /// Compares two CompaintRequest for equality using the person that
        /// submitted the complaint, the complaint text, and
        /// statuses of each request. 
        /// </summary>
        /// <param name="obj">
        /// The complaint request that this request is being compared
        /// </param>
        /// <returns>
        /// True if the same person submitted the complaint, compaint text of 
        /// both request are the same and their statuses are either pending or in-work,
        /// false otherwise
        /// </returns>
        public override bool Equals(object obj)
        {
            if(obj != null && obj.GetType() == GetType())
            {
                var newComplaint = obj as ComplaintRequest;

                return newComplaint.Initiator.Equals(Initiator) &&
                   newComplaint.Accused.Equals(Accused) &&
                   newComplaint.Complaint.ToLower().Equals(Complaint.ToLower()) &&
                   (newComplaint.Status == StatusEnum.PENDING || newComplaint.Status == StatusEnum.INWORK) &&
                   (Status == StatusEnum.PENDING || Status == StatusEnum.INWORK);
            }
            return false;
        }

        /// <summary>
        /// Generate a unique number that represent this object instance
        /// </summary>
        /// <returns>Unique int</returns>
        public override int GetHashCode()
        {
            return Initiator.GetHashCode() + 
               Accused.GetHashCode() + 
               Complaint.GetHashCode() +
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
            return string.Format("{0}\nAccused: {1} Complaint: {2}", 
               base.ToString(), Accused.GetFullName(), Complaint);
        }
   }
}
