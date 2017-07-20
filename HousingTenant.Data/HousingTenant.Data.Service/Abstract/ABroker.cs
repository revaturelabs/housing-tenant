using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousingTenant.Data.Service.Interfaces;

namespace HousingTenant.Data.Service.Abstract
{
    public abstract class ABroker<T> : IBroker<T>
    {
        public bool Create(T obj)
        {
            throw new NotImplementedException ();
        }

        public bool Delete(T obj)
        {
            throw new NotImplementedException ();
        }

        public List<T> Get()
        {
            throw new NotImplementedException ();
        }

        public bool Update(T obj)
        {
            throw new NotImplementedException ();
        }
    }
}
