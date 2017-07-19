using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Library.Models
{
    /// <summary>
    /// Represent a "request" that is serves as the base class
    /// for all types of request that can be submitted by a Tenant.
    /// </summary>
    public abstract class ARequest
    {
        public bool Urgent { get; set; }
        public Person Initiator { get; set; }
        public DateTime DateSubmitted { get; set; }
        public DateTime DateModified { get; set; }
        public StatusEnum Status { get; set; }

        /// <summary>
        /// Determine the validity of an instantiated object
        /// of this class. To be valid depends upon the state
        /// of the object that uniquely make it a valid object
        /// </summary>
        /// <returns>True if the properties of this object contain the minimum require values,
        /// false otherwise</returns>
        public abstract bool IsValid();
        
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
