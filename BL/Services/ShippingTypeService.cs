using BL.Contracts;
using BL.Dtos;
using DAL.Contracts;
using Domains;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Services
{
    public class ShippingTypeService : GenericService<TbShippingType, ShippingTypeDto>, IShippingType
    {
        public ShippingTypeService(ITableRepository<TbShippingType> repository, IMapper mapper) : base(repository, mapper)
        {
           
        }

    }
}
