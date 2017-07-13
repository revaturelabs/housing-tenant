using System;
using System.Collections.Generic;
using System.Text;
using HousingTenant.Data.Library.DataModels;

namespace HousingTenant.Data.Library
{
    public class DataBroker
    {
        public Address GetAddressByID(int addressID)
        {
            // Database, give me a thing
            Address address = new DataModels.Address();


            return address;
        }
    }
}
