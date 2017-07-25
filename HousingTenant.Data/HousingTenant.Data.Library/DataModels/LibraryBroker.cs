using System;
using System.Collections.Generic;
using System.Text;
using HousingTenant.Data.Library.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HousingTenant.Data.Library.DataModels
{
    public class LibraryBroker<T> : ABroker<T> where T : class
    {
        private DbContext _Context;

        public LibraryBroker(DbContext context)
        {
            _Context = context;
        }

        public override List<T> GetAll()
        {
            var list = _Context.Set<T>();

            return list.ToList();
        }

        public override bool Create(T obj)
        {
            return base.Create (obj);
        }
    }
}
