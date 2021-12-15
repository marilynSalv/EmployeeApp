using EmployeeApp.Dal.Repositories;
using System;
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
            var expiration = DateTime.UtcNow.AddMinutes(5);
            await _authenticationRepository.AddRefreshToken(username, refreshToken, expiration);
        }

        public Task<bool> IsRefreshTokenValid(string username, string refreshToken)
        {
            return _authenticationRepository.IsRefreshTokenValid(username, refreshToken);
        }

        public Task InvalidateRefreshToken(string username)
        {
            return _authenticationRepository.InvalidateRefreshToken(username);
        }
    }
}
