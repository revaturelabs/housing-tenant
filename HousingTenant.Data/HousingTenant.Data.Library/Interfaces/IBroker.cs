using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Data.Library.Interfaces
{
    public interface IBroker<T>
    {
        List<T> GetAll();
        bool Create(T obj);
    }
}
