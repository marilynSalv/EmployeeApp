using EmployeeApp.Dal.Dtos;
using Microsoft.AspNetCore.Identity;

namespace EmployeeApp.Business.Services
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