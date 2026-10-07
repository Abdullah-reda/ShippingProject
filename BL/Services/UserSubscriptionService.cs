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
    public class UserSubscriptionService : GenericService<TbUserSubscription, UserSubscriptionDto>, IUserSubscription
    {
        public UserSubscriptionService(ITableRepository<TbUserSubscription> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
