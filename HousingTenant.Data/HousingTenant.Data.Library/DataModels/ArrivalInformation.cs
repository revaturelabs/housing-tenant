using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Data.Library.DataModels
{
    public class ArrivalInformation
    {
        DateTime arrivalDate { get; set; }
        bool hasCar { get; set; }
        Batch batch { get; set; }
    }
}
