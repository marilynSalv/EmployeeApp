using EmployeeApp.Dal.Repositories;
using System.Threading.Tasks;

namespace EmployeeApp.Api.Services
{
    public class AuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        public AuthenticationService(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        public async Task<bool> ValidateLogin(string username, string password)
        {
            var user = await _authenticationRepository.GetUserByUsername(username);
            if (user == null)
            {
                return false;
            }

            return false;
        }
    }
}
