namespace EmployeeApp.Domain.Interfaces.Repositories;

public interface IAuthenticationRepository
{
    Task AddRefreshToken(string username, string refreshToken, DateTime expiration);
    Task<bool> IsRefreshTokenValid(string username, string refreshToken);
    Task InvalidateRefreshToken(string username);
}