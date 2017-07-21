using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousingTenant.Data.Service.Interfaces
{
    public interface IMapper<T,U>
    {
        U MapToU(T obj);
        T MapToT(U obj);
    }
}
