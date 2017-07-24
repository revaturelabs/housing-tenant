using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Library.Models
{
    public interface IPerson
    {
        string GetFullName();

        bool IsValid();
    }
}
