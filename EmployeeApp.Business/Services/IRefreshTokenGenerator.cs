using EmployeeApp.Application.Dtos;
using System.Security.Claims;

namespace EmployeeApp.Application.Services;

public interface IRefreshTokenGenerator
{
    Task<RefreshTokenDto> CreateRefreshToken(Guid userId, Claim[] claims);
    Task AddRefreshToken(Guid userId, string refreshToken);
}