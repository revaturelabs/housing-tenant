using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Library.Models
{
    /// <summary>
    /// Represent a request for accommodation or supplies
    /// </summary>
    public abstract class ARequest
    {
        public bool Urgent { get; set; }
        public Person Initiator { get; set; }
        public DateTime DateSubmitted { get; set; }
        public DateTime DateModified { get; set; }
        public StatusEnum Status { get; set; }

        /// <summary>
        /// Generate a string representation of this class
        /// </summary>
        /// <returns>
        /// String representation of this class instance
        /// </returns>
        public override string ToString()
        {
            return string.Format("From: {0}\nOn: {1}",
               Initiator, DateSubmitted);
        }
    }
}
