using EmployeeApp.Application.Dtos;
using EmployeeApp.Application.Interfaces.Services;
using EmployeeApp.Application.Services;
using EmployeeApp.Application.Utility;
using EmployeeApp.Domain.Interfaces.Repositories;
using EmployeeApp.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Infrastructure.Identity;

public class IdentityAuthenticationService : IIdentityAuthenticationService
{
    private readonly IAuthenticationRepository _authenticationRepository;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IRefreshTokenGenerator _refreshTokenGenerator;
    private readonly ApplicationSettings _applicationSettings;


    public IdentityAuthenticationService(IAuthenticationRepository authenticationRepository,
        IRefreshTokenGenerator refreshTokenGenerator,
        IOptions<ApplicationSettings> applicationSettings,
        UserManager<ApplicationUser> userManager)
    {
        _authenticationRepository = authenticationRepository;
        _userManager = userManager;
        _refreshTokenGenerator = refreshTokenGenerator;
        _applicationSettings = applicationSettings.Value;
    }

    public async Task<Result> CreateUser(RegisterDto registerDto)
    {
        //TODO: validate dto
        var user = new ApplicationUser
        {
            Email = registerDto.Email,
            UserName = registerDto.UserName,
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName,
            ZipCode = registerDto.ZipCode,
            CompanyId = registerDto.CompanyId,
            ManagerId = registerDto.ManagerId,
            IsManager = registerDto.IsManager,
        };
        var result = await _userManager.CreateAsync(user, registerDto.Password);

        return result.Succeeded ? Result.Ok() : Result.Fail(result.Errors.Select(e => e.Description));
    }

    public async Task<AuthResponseDto> LoginUser(LoginDto loginDto)
    {
        var result = new AuthResponseDto();

        var user = await _userManager.FindByNameAsync(loginDto.Username);

        if (user != null && (await _userManager.CheckPasswordAsync(user, loginDto.Password)))
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

            var refreshTokenDto = await _refreshTokenGenerator.CreateRefreshToken(user.Id, claims.ToArray());

            result.Token = refreshTokenDto.Token;
            result.IsAuthSuccessful = true;
            result.RefreshToken = refreshTokenDto.RefreshToken;
        }
        else
        {
            var message = "Username or password is incorrect";
            result.ErrorMessage = message;
            result.IsAuthSuccessful = false;
        }

        return result;
    }

    public async Task<RefreshTokenDto> RefreshToken(RefreshTokenDto dto)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenValidationParams = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            RequireExpirationTime = true,
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = false,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_applicationSettings.JwtSecret)),
        };

        SecurityToken validatedToken = null;
        var principal = tokenHandler.ValidateToken(dto.Token, tokenValidationParams, out validatedToken);
        var jwtToken = validatedToken as JwtSecurityToken;
        var claimValue = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (Guid.TryParse(claimValue, out Guid userId) is false) {
            await InvalidateRefreshToken(userId);
            throw new SecurityTokenException("user id cannot be parsed");
        }

        if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256))
        {
            await InvalidateRefreshToken(userId);
            throw new SecurityTokenException("Invalid token passed");
        }

        var isRefreshTokenValid = await IsRefreshTokenValid(userId, dto.RefreshToken);
        if (!isRefreshTokenValid)
        {
            await InvalidateRefreshToken(userId);
            throw new SecurityTokenException("Invalid token passed");
        }

        var refreshTokenDto = await _refreshTokenGenerator.CreateRefreshToken(userId, principal.Claims.ToArray());

        return refreshTokenDto;
    }

    public Task<bool> IsRefreshTokenValid(Guid userId, string refreshToken)
    {
        return _authenticationRepository.IsRefreshTokenValid(userId, refreshToken);
    }

    public async Task InvalidateRefreshToken(Guid userId)
    {
        await _authenticationRepository.InvalidateRefreshToken(userId);
    }
}
