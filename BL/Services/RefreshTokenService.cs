using AutoMapper;
using BL.Contracts;
using BL.Dtos;
using DAL.Contracts;
using DAL.Repositories;
using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class RefreshTokenService : GenericService<TbRefreshTokens, RefreshTokenDto>, IRefreshTokens
    {
        private readonly ITableRepository<TbRefreshTokens> _repo;
        private readonly IMapper _mapper;
        public RefreshTokenService(ITableRepository<TbRefreshTokens> repository, IMapper mapper) : base(repository, mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }
        public RefreshTokenDto GetByToken(string token)
        {
            var refreshToken = _repo.GetFirstOrDefault(a => a.Token == token);
            return _mapper.Map<TbRefreshTokens, RefreshTokenDto>(refreshToken);
        }

        public bool Refresh(RefreshTokenDto tokenDto)
        {
            var tokenList = _repo.GetList(a => a.UserId == tokenDto.UserId && a.CurrentState == 1);
            foreach (var dbToken in tokenList)
            {
                _repo.ChangeStatus(dbToken.Id, 2);
            }

            var dbTokens = _mapper.Map<RefreshTokenDto, TbRefreshTokens>(tokenDto);
            _repo.Add(dbTokens);
            return true;
        }
    }
}
