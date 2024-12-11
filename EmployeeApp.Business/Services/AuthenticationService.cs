using EmployeeApp.Dal.Dtos;
using EmployeeApp.Dal.Entities;
using EmployeeApp.Dal.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeApp.Api.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IRefreshTokenGenerator _refreshTokenGenerator;
        private readonly ApplicationSettings _applicationSettings;


        public AuthenticationService(IAuthenticationRepository authenticationRepository,
            IRefreshTokenGenerator refreshTokenGenerator,
            IOptions<ApplicationSettings> applicationSettings,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _authenticationRepository = authenticationRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _refreshTokenGenerator = refreshTokenGenerator;
            _applicationSettings = applicationSettings.Value;
        }

        public async Task<IdentityResult> CreateUser(RegisterDto registerDto)
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

            return result;
        }

        public async Task<AuthResponseDto> LoginUser(LoginDto loginDto)
        {
            var result = new AuthResponseDto();

            var user = await _userManager.FindByNameAsync(loginDto.Username);

            if (user != null && (await _signInManager.PasswordSignInAsync(user, loginDto.Password, false, false)).Succeeded)
            {
                var claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName.ToString()),
                };

                var refreshTokenDto = await _refreshTokenGenerator.CreateTokenAndRefresh(loginDto.Username, claims.ToArray());

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
            var username = principal.Identity.Name;

            if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256))
            {
                await InvalidateRefreshToken(username);
                throw new SecurityTokenException("Invalid token passed");
            }

            var isRefreshTokenValid = await IsRefreshTokenValid(username, dto.RefreshToken);
            if (!isRefreshTokenValid)
            {
                await InvalidateRefreshToken(username);
                throw new SecurityTokenException("Invalid token passed");
            }

            var refreshTokenDto = await _refreshTokenGenerator.CreateTokenAndRefresh(username, principal.Claims.ToArray());

            return refreshTokenDto;
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

        public async Task InvalidateRefreshToken(string username)
        {
            await _authenticationRepository.InvalidateRefreshToken(username);
        }
    }
}
