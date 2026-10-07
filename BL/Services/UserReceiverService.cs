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
    public class UserReceiverService : GenericService<TbUserReceiver, UserReceiverDto>, IUserReceiver
    {
        public UserReceiverService(ITableRepository<TbUserReceiver> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
