using Ecommerce.IdentityServer.Dtos;
using Ecommerce.IdentityServer.Models;
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

        public LoginController(SignInManager<ApplicationUser> singInInManager)
        {
            _singInInManager = singInInManager;
        }

        [HttpPost]
        public async  Task<IActionResult> UserLogin(UserLoginDto userLoginDto)
        {
            var result = await _singInInManager.PasswordSignInAsync(userLoginDto.UserName, userLoginDto.Password, false, false);
            //ilk false remember me anlamina gelir
            //kullanici sifreyi yuanlis girdighinde artar 5 oldunca da kilitler
            if (result.Succeeded)
            {
                return Ok("Giris Islemi Basarili ! ");
            }
            else
            {
                return Ok("Kullanici Adi veya Sifre Hatali");
            }


              
             
        }
    }
}
