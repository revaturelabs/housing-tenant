﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousingTenant.Data.Service.Abstract;
using HousingTenant.Data.Service.Interfaces;
using HousingTenant.Data.Service.Factory;
using Microsoft.EntityFrameworkCore;

namespace HousingTenant.Data.Service.Models
{
    public class ServiceBroker<T,U> : ABroker<T> where T : IModel, new() where U : class, new()
    {
        private Library.Interfaces.IBroker<U> lb;
        private IMapper<T, U> sm;

        public ServiceBroker(DbContext context)
        {
            lb = new Library.Factory.BrokerFactory<U> ().CreateLibBroker (context);
            sm = new MapperFactory<T, U> ().Create ();
        }

        public override List<T> GetAll()
        {
            var output = new List<T> ();
            var input = lb.GetAll ();

            foreach (var item in input)
            {
                output.Add (sm.MapToT (item));
            }
            

            return output;
        }

        public override bool Create(T obj)
        {
            return true;
        }
    }
}
