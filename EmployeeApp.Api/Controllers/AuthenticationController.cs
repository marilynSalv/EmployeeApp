using EmployeeApp.Application.Dtos;
using EmployeeApp.Application.Interfaces.Services;
using EmployeeApp.Application.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeApp.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(
            IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        //TEST PIPELINE SYNC
        [HttpPost("register")]
        public async Task<Result> Register([FromBody] RegisterDto registerDto)
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
        }
    }
}
