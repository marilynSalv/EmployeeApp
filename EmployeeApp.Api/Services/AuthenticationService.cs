using EmployeeApp.Dal.Repositories;
using System.Threading.Tasks;

namespace EmployeeApp.Api.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        public AuthenticationService(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        public async Task AddRefreshToken(string username, string refreshToken)
        {
            await _authenticationRepository.AddRefreshToken(username, refreshToken);
        }

        public Task<bool> IsRefreshTokenValid(string username, string refreshToken)
        {
            return _authenticationRepository.IsRefreshTokenValid(username, refreshToken);
        }
    }
}
