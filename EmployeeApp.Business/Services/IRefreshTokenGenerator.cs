using EmployeeApp.Dal.Dtos;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EmployeeApp.Api.Services
{
    public interface IRefreshTokenGenerator
    {
        Task<RefreshTokenDto> CreateTokenAndRefresh(string username, Claim[] claims);
        Task AddRefreshToken(string username, string refreshToken);
    }
}
