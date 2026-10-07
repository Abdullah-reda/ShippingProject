using BL.Contracts;
using DAL.Contracts;
using Domains;
using System;
using System.Collections.Generic;
using System.Text;
using BL.Dtos;
using AutoMapper;

namespace BL.Services
{
    public class SettingService : GenericService<TbSetting, SettingDto>, ISetting
    {
        public SettingService(ITableRepository<TbSetting> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
