using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousingTenant.Business.Service.Interfaces
{
    /// <summary>
    /// The base interface for all Brokers used by the Business Service
    /// </summary>
    public interface IBroker<T,U,V>
    {
        
        List<T> Get();
        List<T> Get(U obj);
        bool Create(V obj);
        bool Delete(T obj);
        bool Update(T obj);
    }
}
