using EmployeeApp.Domain.Interfaces.Repositories;
using EmployeeApp.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Infrastructure.Repositories;

public class AuthenticationRepository : IAuthenticationRepository
{
    private readonly PlayGroundContext _context;

    public AuthenticationRepository(PlayGroundContext context)
    {
        _context = context;
    }

    public async Task AddRefreshToken(Guid userId, string refreshToken, DateTime expiration)
    {
        var entity = await _context.ApplicationUsers
            .Where(x => x.Id == userId)
            .SingleAsync();

        entity.RefreshToken = refreshToken;
        entity.RefreshTokenExpiration = expiration;
        entity.RefreshTokenCreatedOn = DateTime.UtcNow;
        entity.RefreshTokenValid = true;

        await _context.SaveChangesAsync();
    }

    public async Task<bool> IsRefreshTokenValid(Guid userId, string refreshToken)
    {
        var exists = await _context.ApplicationUsers
            .Where(x => x.Id == userId)
            .Where(x => DateTime.UtcNow <= x.RefreshTokenExpiration)
            .Where(x => x.RefreshToken == refreshToken)
            .Where(x => x.RefreshTokenValid == true)
            .AnyAsync();

        return exists;
    }

    public async Task InvalidateRefreshToken(Guid userId)
    {
        var entity = await _context.ApplicationUsers
            .Where(x => x.Id == userId)
            .SingleAsync();

        entity.RefreshTokenValid = false;

        await _context.SaveChangesAsync();
    }
}
