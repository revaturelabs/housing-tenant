using HousingTenant.Business.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Library
{
    public interface IApartment
    {
        bool AddRequest(ARequest request);

        bool AddTenant(IPerson tenant);

        List<ARequest> OpenRequests();
    }
}
