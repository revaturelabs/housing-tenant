using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousingTenant.Data.Service.Models;

namespace HousingTenant.Data.Service.Factory
{
    public class MapperFactory<T,U> where T : new() where U : new()
    {
        public ServiceMapper<T,U> Create()
        {
            return new ServiceMapper<T, U> ();
        }
    }
}
