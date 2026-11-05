using AutoMapper;
using BL.Contracts;
using BL.Dtos;
using DAL.Contracts;
using Domains;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BL.Services
{
    public class CityService : GenericService<TbCity, CityDto>, ICity
    {
        private readonly IViewRepository<VwCities> _Viewrepo;
        IMapper _mapper;
        public CityService(ITableRepository<TbCity> repository, IMapper mapper, IViewRepository<VwCities> viewrepo) : base(repository, mapper)
        {
            _Viewrepo = viewrepo;
            _mapper = mapper;
        }

        public IEnumerable<CityDto> GitAllCitites()
        {
            var cities = _Viewrepo.GetAll().Where(a => a.CurrentState >= 1).ToList();
            return _mapper.Map<IEnumerable<VwCities>, IEnumerable<CityDto>>(cities).ToList();
        }
    }
}
