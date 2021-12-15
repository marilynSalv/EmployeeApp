using System.Threading.Tasks;

namespace EmployeeApp.Api.Services
{
    public interface IAuthenticationService
    {
        Task AddRefreshToken(string username, string refreshToken);
        Task<bool> IsRefreshTokenValid(string username, string refreshToken);
        Task InvalidateRefreshToken(string username);
    }
}