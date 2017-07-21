using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousingTenant.Data.Service.Interfaces;

namespace HousingTenant.Data.Service.Models
{
    public class ServiceMapper<T,U> : IMapper<T,U> where T : new() where U : new()
    {
        private MapperConfiguration tTou = new MapperConfiguration (p => p.CreateMap<T, U> ());
        private MapperConfiguration uTot = new MapperConfiguration (p => p.CreateMap<U, T> ());

        public U MapToU(T obj)
        {
            return tTou.CreateMapper ().Map<U> (obj);
        }

        public T MapToT(U obj)
        {
            return tTou.CreateMapper ().Map<T> (obj);
        }
    }
}
