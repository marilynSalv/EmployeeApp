using EmployeeApp.Dal.Dtos;
using EmployeeApp.Dal.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace EmployeeApp.Api.Services;

public class RefreshTokenGenerator : IRefreshTokenGenerator
{
    private readonly IAuthenticationRepository _authenticationRepository;
    private readonly ApplicationSettings _applicationSettings;

    public RefreshTokenGenerator(IAuthenticationRepository authenticationRepository,
        IOptions<ApplicationSettings> applicationSettings)
    {
        _authenticationRepository = authenticationRepository;
        _applicationSettings = applicationSettings.Value;
    }

    public async Task<RefreshTokenDto> CreateTokenAndRefresh(string username, Claim[] claims)
    {
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(3),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_applicationSettings.JwtSecret)), SecurityAlgorithms.HmacSha256Signature),
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        var token = tokenHandler.WriteToken(securityToken);

        // Random # generator
        var refreshToken = GenerateToken();
        await AddRefreshToken(username, refreshToken);

        var result = new RefreshTokenDto
        {
            Token = token,
            RefreshToken = refreshToken,
        };

        return result;
    }

    public async Task AddRefreshToken(string username, string refreshToken)
    {
        var expiration = DateTime.UtcNow.AddMinutes(5);
        await _authenticationRepository.AddRefreshToken(username, refreshToken, expiration);
    }

    private string GenerateToken()
    {
        var randomNumber = new byte[32];
        using var randomNumGenerator = RandomNumberGenerator.Create();

        randomNumGenerator.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }
}
