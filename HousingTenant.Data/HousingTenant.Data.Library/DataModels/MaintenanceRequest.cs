using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Data.Library.DataModels
{
    public class MaintenanceRequest
    {
        public string content { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string maintenanceType { get; set; }

        public DateTime timeOfRequest { get; set; }
    }
}
