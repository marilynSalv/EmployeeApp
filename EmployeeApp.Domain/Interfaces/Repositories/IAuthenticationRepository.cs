namespace EmployeeApp.Domain.Interfaces.Repositories;

public interface IAuthenticationRepository
{
    Task AddRefreshToken(Guid userId, string refreshToken, DateTime expiration);
    Task<bool> IsRefreshTokenValid(Guid userId, string refreshToken);
    Task InvalidateRefreshToken(Guid userId);
}