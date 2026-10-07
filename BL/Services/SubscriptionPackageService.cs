using System;
using System.Collections.Generic;
using System.Text;
using Domains;
using DAL.Contracts;
using BL.Contracts;
using BL.Dtos;
using AutoMapper;

namespace BL.Services
{
    public class SubscriptionPackageService : GenericService<TbSubscriptionPackage, SubscriptionPackageDto>, ISubscriptionPackage
    {
        public SubscriptionPackageService(ITableRepository<TbSubscriptionPackage> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
