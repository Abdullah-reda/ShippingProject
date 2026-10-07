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
    public class CarrierService : GenericService<TbCarrier, CarrierDto>, ICarrier
    {
        public CarrierService(ITableRepository<TbCarrier> repository, IMapper mapper) : base(repository, mapper )
        {
        }
    }

}
