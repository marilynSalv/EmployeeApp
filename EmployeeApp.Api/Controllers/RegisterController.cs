using EmployeeApp.Dal.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeApp.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public RegisterController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpPost("register")]
        public async Task<IdentityResult> Register([FromBody] RegisterDto registerDto)
        {
            //TODO: validate dto
            var user = new IdentityUser
            {
                Email = registerDto.Email,
                UserName = registerDto.Password,
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false); //2nd param if want to create session cookie(false) lost after close wndow, or permanant cookie
            }
            return result;
        }
    }
}
