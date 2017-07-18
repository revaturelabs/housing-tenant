using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousingTenant.Data.Service.Interface
{
    public interface IBroker<T>
    {
        List<T> Get();
        bool Create(T obj);
        bool Update(T obj);
        bool Delete(T obj);
    }
}
