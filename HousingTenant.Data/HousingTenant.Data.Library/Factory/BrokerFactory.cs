using System;
using System.Collections.Generic;
using System.Text;
using HousingTenant.Data.Library.DataModels;
using Microsoft.EntityFrameworkCore;

namespace HousingTenant.Data.Library.Factory
{
    public class BrokerFactory<T> where T : class
    {
        public LibraryBroker<T> CreateLibBroker(DbContext context)
        {
            return new LibraryBroker<T> (context);
        }
    }
}
