using System;
using System.Collections.Generic;
using System.Text;
using Domains;
using BL.Contracts;
using DAL.Contracts;
using BL.Dtos;
using AutoMapper;

namespace BL.Services
{
    public class ShippmentService : GenericService<TbShippment, ShippmentDto>, IShippment
    {
        public ShippmentService(ITableRepository<TbShippment> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
