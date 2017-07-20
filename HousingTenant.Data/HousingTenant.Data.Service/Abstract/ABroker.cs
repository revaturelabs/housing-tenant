using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousingTenant.Data.Service.Interfaces;

namespace HousingTenant.Data.Service.Abstract
{
    public abstract class ABroker<T> : IBroker<T> where T : IModel
    {
        public virtual bool Create(T obj)
        {
            throw new NotImplementedException ();
        }

        public virtual bool Delete(T obj)
        {
            throw new NotImplementedException ();
        }

        public virtual List<T> Get()
        {
            throw new NotImplementedException ();
        }

        public virtual bool Update(T obj)
        {
            throw new NotImplementedException ();
        }
    }
}
