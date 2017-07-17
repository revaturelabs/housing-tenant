using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Data.Library.DataModels
{
    public class ArrivalInformation
    {
        public DateTime arrivalDate { get; set; }
        public bool hasCar { get; set; }
        public Batch batch { get; set; }
    }
}
