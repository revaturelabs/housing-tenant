using System;
using System.Collections.Generic;
using System.Text;
using HousingTenant.Data.Library.DataModels;

namespace HousingTenant.Data.Library.Factory
{
    public class BrokerFactory<T>
    {
        public LibraryBroker<T> Create()
        {
            return new LibraryBroker<T> ();
        }
    }
}
