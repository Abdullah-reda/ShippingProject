using System;
using System.Collections.Generic;
using System.Text;
using Domains;
using BL.Dtos;

namespace BL.Contracts
{
    public interface IRefreshTokens : IGenericService<TbRefreshTokens, RefreshTokenDto>
    {
        public RefreshTokenDto GetByToken(string token);
        public bool Refresh(RefreshTokenDto tokenDto);
    }
}
