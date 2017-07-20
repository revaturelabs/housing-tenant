using System;
using System.Collections.Generic;
using System.Text;
using HousingTenant.Data.Library.Interfaces;

namespace HousingTenant.Data.Library.Abstract
{
    public abstract class ABroker<T> : IBroker<T>
    {
        public virtual bool Create(T obj)
        {
            throw new NotImplementedException ();
        }

        public virtual List<T> GetAll()
        {
            throw new NotImplementedException ();
        }
    }
}
