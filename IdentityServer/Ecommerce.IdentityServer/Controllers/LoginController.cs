using Ecommerce.IdentityServer.Dtos;
using Ecommerce.IdentityServer.Models;
using Ecommerce.IdentityServer.Tools;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecommerce.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _singInManager;

        private readonly UserManager<ApplicationUser> _userManager;

        public LoginController(SignInManager<ApplicationUser> singInManager, UserManager<ApplicationUser> userManager)
        {
            _singInManager = singInManager;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLoginDto userLoginDto)
        {
            var result = await _singInManager.PasswordSignInAsync(userLoginDto.UserName, userLoginDto.Password, false, false);
            var user = await _userManager.FindByNameAsync(userLoginDto.UserName);
            if (result.Succeeded)
            {
                GetCheckAppUserViewModel getCheckAppUserViewModel = new GetCheckAppUserViewModel();
                getCheckAppUserViewModel.UserName = userLoginDto.UserName;
                getCheckAppUserViewModel.Id = user.Id;
                var token = JwtTokenGenerator.GenerateToken(getCheckAppUserViewModel);
                return Ok(token);
            }
            else
            {
                return Ok("Failed to log in");
            }
        }
    }
}
