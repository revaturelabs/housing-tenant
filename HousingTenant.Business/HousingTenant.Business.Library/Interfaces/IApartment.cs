﻿using HousingTenant.Business.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Library.Models
{
    public interface IApartment : IComparable<IApartment>
    {
        bool AddRequest(ARequest request);

        bool AddTenant(IPerson tenant);

        List<ARequest> OpenRequests();

        bool IsValid();
    }
}
