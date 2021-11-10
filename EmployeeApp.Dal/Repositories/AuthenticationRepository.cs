using EmployeeApp.Dal.Contexts;
using EmployeeApp.Dal.Dtos;
using Microsoft.EntityFrameworkCore;
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

        public async Task AddRefreshToken(string username, string refreshToken)
        {
            var entity = await _context.ApplicationUsers
                .Where(x => x.UserName == username)
                .SingleAsync();

            entity.RefreshToken = refreshToken;

            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsRefreshTokenValid(string username, string refreshToken)
        {
            var exists = await _context.ApplicationUsers
                .Where(x => x.UserName == username)
                .Where(x => x.RefreshToken == refreshToken)
                .AnyAsync();

            return exists;
        }
    }
}
