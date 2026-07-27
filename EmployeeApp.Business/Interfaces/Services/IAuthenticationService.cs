using EmployeeApp.Application.Dtos;
using EmployeeApp.Application.Utility;

namespace EmployeeApp.Application.Interfaces.Services;

public interface IAuthenticationService
{
    Task<Result> CreateUser(RegisterDto registerDto);
    Task<AuthResponseDto> LoginUser(LoginDto loginDto);
    Task AddRefreshToken(string username, string refreshToken);
    Task<bool> IsRefreshTokenValid(string username, string refreshToken);
    Task InvalidateRefreshToken(string username);
    Task<RefreshTokenDto> RefreshToken(RefreshTokenDto dto);
}
