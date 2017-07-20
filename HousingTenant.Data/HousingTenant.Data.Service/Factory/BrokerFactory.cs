using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousingTenant.Data.Service.Models;
using HousingTenant.Data.Service.Interfaces;

namespace HousingTenant.Data.Service.Factory
{
    public class BrokerFactory<T> where T : IModel, new()
    {
        public ServiceBroker<T> Create()
        {
            return new ServiceBroker<T>();
        }
    }
}
