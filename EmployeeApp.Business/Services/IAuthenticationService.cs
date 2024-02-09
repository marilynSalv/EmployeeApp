using EmployeeApp.Dal.Dtos;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace EmployeeApp.Api.Services
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> CreateUser(RegisterDto registerDto);
        Task<AuthResponseDto> LoginUser(LoginDto loginDto);
        Task AddRefreshToken(string username, string refreshToken);
        Task<bool> IsRefreshTokenValid(string username, string refreshToken);
        Task InvalidateRefreshToken(string username);
        Task<RefreshTokenDto> RefreshToken(RefreshTokenDto dto);
    }
}