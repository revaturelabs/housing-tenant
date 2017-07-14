using System;
using System.Collections.Generic;
using System.Text;
using HousingTenant.Data.Library.DataModels;

namespace HousingTenant.Data.Library.DataModels
{
    public class Apartment
    {
        public Address address { get; set; }
        public bool walkingDist { get; set; }
        public int numBeds { get; set; }
        public string gender { get; set; }
        public string complexString { get; set; }
        public int numCars { get; set; }
    }
}
