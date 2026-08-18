using EmployeeApp.Application.Dtos;
using EmployeeApp.Application.Utility;

namespace EmployeeApp.Application.Interfaces.Services;

public interface IIdentityAuthenticationService
{
    Task<Result> CreateUser(RegisterDto registerDto);
    Task<AuthResponseDto> LoginUser(LoginDto loginDto);
    Task<bool> IsRefreshTokenValid(Guid userId, string refreshToken);
    Task InvalidateRefreshToken(Guid userId);
    Task<RefreshTokenDto> RefreshToken(RefreshTokenDto dto);
}
