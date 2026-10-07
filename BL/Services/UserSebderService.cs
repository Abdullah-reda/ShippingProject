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
    public class UserSebderService : GenericService<TbUserSebder, UserSebderDto>, IUserSebder
    {
        public UserSebderService(ITableRepository<TbUserSebder> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
