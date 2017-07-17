using System;
using System.Collections.Generic;
using System.Text;
using HousingTenant.Data.Library.Models;

namespace HousingTenant.Data.Library
{
    public class DataBroker
    {
        static TenantDBContext context = new TenantDBContext();

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


        public List<Person> GetPeopleList( )
        {

            try
            {
                var everyone = new List<Person>();
                foreach (var item in context.Person)
                {
                    everyone.Add(item);
                }

                return everyone;
            }

            catch(InvalidOperationException e)
            {
                Console.WriteLine("Could not get Person object out of Context\n" + e.Message);
                return null;
            }

        }
    }
}
