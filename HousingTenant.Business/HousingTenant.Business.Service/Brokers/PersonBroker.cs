﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousingTenant.Business.Library.Models;
using HousingTenant.Business.Service.Interfaces;

namespace HousingTenant.Business.Service.Brokers
{
    public class PersonBroker : IBroker<Person, string, Person>
    {
        public bool Create(Person obj)
        {
            throw new NotImplementedException ();
        }

        public bool Delete(Person obj)
        {
            throw new NotImplementedException ();
        }

        public List<Person> Get()
        {
            throw new NotImplementedException ();
        }

        public List<Person> Get(string obj)
        {
            throw new NotImplementedException ();
        }

        public bool Update(Person obj)
        {
            throw new NotImplementedException ();
        }
    }
}
