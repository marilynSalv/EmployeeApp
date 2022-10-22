using EmployeeApp.Api.Services;
using EmployeeApp.Dal.Dtos;
using EmployeeApp.Dal.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeApp.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(
            SignInManager<ApplicationUser> signInManager,
            IAuthenticationService authenticationService)
        {
            _signInManager = signInManager;
            _authenticationService = authenticationService;
        }

        //TEST PIPELINE SYNC
        [HttpPost("register")]
        public async Task<IdentityResult> Register([FromBody] RegisterDto registerDto)
        {
            var result = await _authenticationService.CreateUser(registerDto);

            return result;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var result = await _authenticationService.LoginUser(loginDto);

            if (result.IsAuthSuccessful)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("refreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto dto)
        {
            var refreshTokenDto = await _authenticationService.RefreshToken(dto);
            if (refreshTokenDto != null)
            {
                return Ok(refreshTokenDto);
            }

            return Unauthorized();
        }

        [HttpPut("logout")]
        public async Task Logout(string username)
        {
            var x = User.Identity.Name;
            await _authenticationService.InvalidateRefreshToken(username);
            await _signInManager.SignOutAsync();
        }
    }
}
