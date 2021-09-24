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

        public async Task<AspNetUserDto> GetUserByUsername(string username)
        {

            var result = await _context.ApplicationUsers
                .Where(x => x.UserName == username)
                .Select(x => new AspNetUserDto
                {
                    Username = x.UserName,
                    PasswordHash = x.PasswordHash,
                    LockoutEnabled = x.LockoutEnabled,
                    LockoutEndDate = x.LockoutEnd,
                })
                .SingleOrDefaultAsync();

            return result;
        }
    }
}
