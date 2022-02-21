using EmployeeApp.Dal.Contexts;
using EmployeeApp.Dal.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Dal.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly PlayGroundContext _context;

        public AuthenticationRepository(PlayGroundContext context)
        {
            _context = context;
        }

        public async Task AddRefreshToken(string username, string refreshToken, DateTime expiration)
        {
            var entity = await _context.ApplicationUsers
                .Where(x => x.UserName == username)
                .SingleAsync();

            entity.RefreshToken = refreshToken;
            entity.RefreshTokenExpiration = expiration;
            entity.RefreshTokenCreatedOn = DateTime.UtcNow;
            entity.RefreshTokenValid = true;

            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsRefreshTokenValid(string username, string refreshToken)
        {
            var exists = await _context.ApplicationUsers
                .Where(x => x.UserName == username)
                .Where(x => DateTime.UtcNow <= x.RefreshTokenExpiration)
                .Where(x => x.RefreshToken == refreshToken)
                .Where(x => x.RefreshTokenValid == true)
                .AnyAsync();

            return exists;
        }

        public async Task InvalidateRefreshToken(string username)
        {
            var entity = await _context.ApplicationUsers
                .Where(x => x.UserName == username)
                .SingleAsync();

            entity.RefreshTokenValid = false;

            await _context.SaveChangesAsync();
        }
    }
}
