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
        private readonly SignInManager<ApplicationUser> _singInInManager;

        private readonly UserManager<ApplicationUser> _userManager;

        public LoginController(SignInManager<ApplicationUser> singInInManager, UserManager<ApplicationUser> userManager)
        {
            _singInInManager = singInInManager;
            _userManager = userManager;
        }

        [HttpPost]
        public async  Task<IActionResult> UserLogin(UserLoginDto userLoginDto)
        {
            var result = await _singInInManager.PasswordSignInAsync(userLoginDto.UserName, userLoginDto.Password, false, false);
            //ilk false remember me anlamina gelir
            //kullanici sifreyi yuanlis girdighinde artar 5 oldunca da kilitler
            var user = await _userManager.FindByNameAsync(userLoginDto.UserName);
            if (result.Succeeded)
            {
                GetCheckAppUserViewModel model = new GetCheckAppUserViewModel();
                model.UserName = userLoginDto.UserName;
                model.Id = user.Id;
                var token = JwtTokenGenerator.GenerateToken(model);
                return Ok(token);
            }
            else
            {
                return Ok("Kullanici Adi veya Sifre Hatali");
            }


              
             
        }
    }
}
