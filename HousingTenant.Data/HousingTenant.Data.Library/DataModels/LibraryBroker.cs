using System;
using System.Collections.Generic;
using System.Text;
using HousingTenant.Data.Library.Abstract;

namespace HousingTenant.Data.Library.DataModels
{
    public class LibraryBroker<T> : ABroker<T> where T : new()
    {
        public override List<T> GetAll()
        {
            var list = new List<T> ();

            list.Add (new T ());

            return list;
        }

        public override bool Create(T obj)
        {
            return base.Create (obj);
        }
    }
}
