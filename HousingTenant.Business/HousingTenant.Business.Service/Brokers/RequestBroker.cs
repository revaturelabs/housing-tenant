﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousingTenant.Business.Service.Interfaces;
using HousingTenant.Business.Library.Models;

namespace HousingTenant.Business.Service.Brokers
{
    public class RequestBroker : IBroker<ARequest>
    {
        public bool Create(ARequest obj)
        {
            throw new NotImplementedException ();
        }

        public bool Delete(ARequest obj)
        {
            throw new NotImplementedException ();
        }

        public List<ARequest> Get()
        {
            throw new NotImplementedException ();
        }

        public bool Update(ARequest obj)
        {
            throw new NotImplementedException ();
        }
    }
}