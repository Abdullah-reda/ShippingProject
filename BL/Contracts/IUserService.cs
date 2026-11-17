using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Dtos;
namespace BL.Contracts
{
    public interface IUserService
    {
        Task<UserResultDto> RegisterAsync(UserDto registerDto);
        Task<UserResultDto> LoginAsync(UserDto loginDto);
        Task LogoutAsync();
        Task<UserDto> GetUserByIdAsync(string userId);
        Task<UserDto> GetUserByEmailAsync(string email);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Guid GetLoggedInUser();
    }
}
