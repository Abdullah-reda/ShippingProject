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
    public class CountryService : GenericService<TbCountry, CountryDto>, ICountry
    {
        public CountryService(ITableRepository<TbCountry> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
