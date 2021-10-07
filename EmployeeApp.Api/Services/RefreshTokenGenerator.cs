using System;
using System.Security.Cryptography;

namespace EmployeeApp.Api.Services
{
    public class RefreshTokenGenerator : IRefreshTokenGenerator
    {
        public string GenerateToken()
        {
            var randomNumber = new byte[32];
            using var randomNumGenerator = RandomNumberGenerator.Create();

            randomNumGenerator.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}
