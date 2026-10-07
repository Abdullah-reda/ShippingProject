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
    public class ShippmentStatusService : GenericService<TbShippmentStatus, ShippmentStatusDto>, IShippmentStatus
    {
        public ShippmentStatusService(ITableRepository<TbShippmentStatus> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
