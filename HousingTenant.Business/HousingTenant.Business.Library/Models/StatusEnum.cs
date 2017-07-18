using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Business.Library.Models
{
    /// <summary>
    /// Represent the status that a Request Object
    /// can have during it's lifecycle
    /// </summary>
    public enum StatusEnum
    {
        PENDING,
        INWORK,
        COMPLETED,
        REJECTED
    }
}
