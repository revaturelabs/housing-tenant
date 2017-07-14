using AutoMapper;
//using HousingTenant.Data.Service.Models;
//using HousingTenant.Data.Library.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousingTenant.Data.Service.Mapper
{
    public class Mapper1
    {
    private MapperConfiguration AddressEntity_AddressAPI = new MapperConfiguration(c => c.CreateMap<Library.Models.Address, Library.Models.Address>());


    public T AddressEntitytoAddressAPI<T>(Library.Models.Address a)
    {
      return AddressEntity_AddressAPI.CreateMapper().Map<T>(a);
    }

  }
}
