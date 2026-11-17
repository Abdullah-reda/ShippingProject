using DAL.UserModels;
using System.Security.Claims;

namespace WebApi.Services;

public interface IJwtService
{
    string GenerateAccessToken(IEnumerable<Claim> claims);

    string GenerateRefreshToken();
}