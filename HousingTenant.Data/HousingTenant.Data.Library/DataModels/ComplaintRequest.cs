using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Data.Library.DataModels
{
    public class ComplaintRequest
    {
        public string content { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public DateTime timeOfRequest { get; set; }
    }
}
