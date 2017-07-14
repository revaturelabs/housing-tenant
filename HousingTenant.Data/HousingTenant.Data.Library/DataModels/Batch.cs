using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Data.Library.DataModels
{
    public class Batch
    {
        public string batchName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
