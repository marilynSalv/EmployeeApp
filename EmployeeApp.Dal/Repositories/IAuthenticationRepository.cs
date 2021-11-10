﻿using EmployeeApp.Dal.Dtos;
using System.Threading.Tasks;

namespace EmployeeApp.Dal.Repositories
{
    public interface IAuthenticationRepository
    {
        Task AddRefreshToken(string username, string refreshToken);
        Task<bool> IsRefreshTokenValid(string username, string refreshToken);
    }
}