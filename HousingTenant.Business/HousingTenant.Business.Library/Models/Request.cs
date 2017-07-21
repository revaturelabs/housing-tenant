using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Library.Models
{
    public abstract class ARequest
    {
        public bool Urgent { get; set; }
        public string RequestId { get; set; }
        public string Description { get; set; }
        public Person Initiator { get; set; }
        public DateTime DateSubmitted { get; set; }
        public DateTime DateModified { get; set; }
        public StatusEnum Status { get; set; }
      
        public abstract bool IsValid();
        
        public override string ToString()
        {
            return string.Format("From: {0}, On: {1}",
               Initiator, DateSubmitted);
        }
    }
}
