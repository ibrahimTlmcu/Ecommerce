 using Ecommerce.IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace Ecommerce.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
    

        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser()
        {
            var userClaims = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);
            var user = await _userManager.FindByIdAsync(userClaims.Value);
            return Ok(new
            {
                Id = user.Id,
                Name = user.UserName,
                Surname = user.Surname,
                Email = user.Email,
                UserName = user.UserName
            });
        }
        [HttpGet("GetAllUserList")]
        public async Task<IActionResult> GetAllUserList()
        {
            var users = await _userManager.Users.ToListAsync();
            return Ok(users);
        }
    }
}
