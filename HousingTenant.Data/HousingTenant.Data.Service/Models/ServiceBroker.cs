using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousingTenant.Data.Service.Abstract;
using HousingTenant.Data.Service.Interfaces;

namespace HousingTenant.Data.Service.Models
{
    public class ServiceBroker<T> : ABroker<T> where T : IModel, new()
    {
        public override List<T> Get()
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
