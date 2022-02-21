using EmployeeApp.Dal.Dtos;
using System;
using System.Threading.Tasks;

namespace EmployeeApp.Dal.Repositories
{
    public interface IAuthenticationRepository
    {
        Task AddRefreshToken(string username, string refreshToken, DateTime expiration);
        Task<bool> IsRefreshTokenValid(string username, string refreshToken);
        Task InvalidateRefreshToken(string username);
    }
}