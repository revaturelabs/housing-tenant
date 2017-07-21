using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousingTenant.Data.Service.Abstract;
using HousingTenant.Data.Service.Interfaces;
using HousingTenant.Data.Library.Factory;
using HousingTenant.Data.Library.DataModels;

namespace HousingTenant.Data.Service.Models
{
    public class ServiceBroker<T,U> : ABroker<T> where T : IModel, new() where U : new()
    {
        private LibraryBroker<U> lb = new Library.Factory.BrokerFactory<U> ().Create();

        public override List<T> GetAll()
        {
            var list = new List<T> ();

            list.Add (new T());

            return list;
        }

        public override bool Create(T obj)
        {
            return true;
        }
    }
}
