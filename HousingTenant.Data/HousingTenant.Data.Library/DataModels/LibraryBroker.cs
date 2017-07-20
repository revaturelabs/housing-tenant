using System;
using System.Collections.Generic;
using System.Text;
using HousingTenant.Data.Library.Abstract;

namespace HousingTenant.Data.Library.DataModels
{
    public class LibraryBroker<T> : ABroker<T>
    {
        public override List<T> GetAll()
        {
            return base.GetAll ();
        }

        public override bool Create(T obj)
        {
            return base.Create (obj);
        }
    }
}
