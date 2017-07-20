using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousingTenant.Data.Service.Interfaces
{
    public interface IBroker<T> where T : IModel
    {
        List<T> GetAll();
        bool Create(T obj);
        bool Update(T obj);
        bool Delete(T obj);
    }
}
