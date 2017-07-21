using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousingTenant.Data.Service.Models;
using HousingTenant.Data.Service.Interfaces;

namespace HousingTenant.Data.Service.Factory
{
    public class BrokerFactory<T,U> where T : IModel, new() where U : new()
    {
        public ServiceBroker<T,U> Create()
        {
            return new ServiceBroker<T,U>();
        }
    }
}
