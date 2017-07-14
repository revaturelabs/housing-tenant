using System;
using System.Collections.Generic;
using System.Text;
using HousingTenant.Data.Library.Models;

namespace HousingTenant.Data.Library
{
    public class DataBroker
    {
        
        public Address GetAddressByID(int addressID)
        {
            // Database, give me a thing
            Address address = new Address()
            {
                Address1 = "1234 Nowhere St.",
                Address2 = "Apt, 5",
                City = "Reston",
                State = "VA",
                Zip = 18555
            };

            return address;
        }
    }
}
