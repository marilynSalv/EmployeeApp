using EmployeeApp.Application.Dtos;
using System.Security.Claims;

namespace EmployeeApp.Application.Services;

public interface IRefreshTokenGenerator
{
    Task<RefreshTokenDto> CreateTokenAndRefresh(string username, Claim[] claims);
    Task AddRefreshToken(string username, string refreshToken);
}