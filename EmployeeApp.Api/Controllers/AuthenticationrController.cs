using EmployeeApp.Api.Services;
using EmployeeApp.Dal.Dtos;
using EmployeeApp.Dal.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationrController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationSettings _applicationSettings;
        private readonly IRefreshTokenGenerator _refreshTokenGenerator;
        private readonly Services.IAuthenticationService _authenticationService;

        public AuthenticationrController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IOptions<ApplicationSettings> applicationSettings,
            IRefreshTokenGenerator refreshTokenGenerator,
            Services.IAuthenticationService authenticationService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _applicationSettings = applicationSettings.Value;
            _refreshTokenGenerator = refreshTokenGenerator;
            _authenticationService = authenticationService;
        }


        [HttpPost("Register")]
        public async Task<IdentityResult> Register([FromBody] RegisterDto registerDto)
        {
            //TODO: validate dto
            var user = new ApplicationUser
            {
                Email = registerDto.Email,
                UserName = registerDto.UserName,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                ZipCode = registerDto.ZipCode,
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            return result;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Username);

            if (user != null && (await _signInManager.PasswordSignInAsync(user, loginDto.Password, false, false)).Succeeded)
            {
                var claims = new Claim[] 
                {
                    new Claim(ClaimTypes.Name, user.UserName.ToString()),
                };
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
                var refreshToken = _refreshTokenGenerator.GenerateToken();
                await _authenticationService.AddRefreshToken(user.UserName, refreshToken);

                var result = new AuthResponseDto
                {
                    Token = token,
                    IsAuthSuccessful = true,
                    RefreshToken = refreshToken,
                };

                return Ok(result);
            }
            else
            {
                var message = "Username or password is incorrect";
                var result = new AuthResponseDto
                {
                    ErrorMessage = message,
                    IsAuthSuccessful = false,
                };
                return BadRequest(result);
            }
        }

        [HttpPut("logout")]
        public async Task Logout(string username)
        {
            var x = User.Identity.Name;
            await _authenticationService.InvalidateRefreshToken(username);
            await _signInManager.SignOutAsync();
        }

        [HttpPost("refreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto dto)
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

            if (jwtToken == null  || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256))
            {
                throw new SecurityTokenException("Invalid token passed");
            }

            var username = principal.Identity.Name;
            var isRefreshTokenValid = await _authenticationService.IsRefreshTokenValid(username, dto.RefreshToken);
            if (!isRefreshTokenValid)
            {
                throw new SecurityTokenException("Invalid token passed");
            }

            var refreshTokenDto = await CreateTokenAndRefresh(username, principal.Claims.ToArray());
            if (refreshTokenDto != null)
            {
                return Ok(refreshTokenDto);
            }

            return Unauthorized();
        }

        private async Task<RefreshTokenDto> CreateTokenAndRefresh(string username, Claim[] claims)
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
            var refreshToken = _refreshTokenGenerator.GenerateToken();
            await _authenticationService.AddRefreshToken(username, refreshToken);

            var result = new RefreshTokenDto
            {
                Token = token,
                RefreshToken = refreshToken,
            };

            return result;
        }
    }
}
