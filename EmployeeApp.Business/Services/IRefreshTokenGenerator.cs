using EmployeeApp.Dal.Dtos;
using System.Security.Claims;

namespace EmployeeApp.Business.Services
{
    public interface IRefreshTokenGenerator
    {
        Task<RefreshTokenDto> CreateTokenAndRefresh(string username, Claim[] claims);
        Task AddRefreshToken(string username, string refreshToken);
    }
}
