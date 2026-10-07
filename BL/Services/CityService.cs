using System;
using System.Collections.Generic;
using System.Text;
using DAL.Contracts;
using Domains;
using BL.Contracts;
using BL.Dtos;
using AutoMapper;

namespace BL.Services
{
    public class CityService : GenericService<TbCity, CityDto>, ICity
    {
        public CityService(ITableRepository<TbCity> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
