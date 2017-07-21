﻿using System;
using System.Collections.Generic;
using System.Text;
using HousingTenant.Data.Library.DataModels;

namespace HousingTenant.Data.Library.Factory
{
    public class BrokerFactory<T> where T : new()
    {
        public LibraryBroker<T> Create()
        {
            return new LibraryBroker<T> ();
        }
    }
}