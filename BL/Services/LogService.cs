using DAL.Contracts;
using Domains;
using System;
using System.Collections.Generic;
using System.Text;
using BL.Contracts;
using BL.Dtos;
using AutoMapper;

namespace BL.Services
{
    public class LogService : GenericService<Log, LogDto>, ILog
    {
        public LogService(ITableRepository<Log> repository, IMapper mapper) : base(repository, mapper)
        {

        }

    }
}
