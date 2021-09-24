using EmployeeApp.Dal.Dtos;
using System.Threading.Tasks;

namespace EmployeeApp.Dal.Repositories
{
    public interface IAuthenticationRepository
    {
        Task<AspNetUserDto> GetUserByUsername(string username);
    }
}