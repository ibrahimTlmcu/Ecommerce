using Ecommerce.IdentityServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Ecommerce.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public StatisticsController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult GetUserCount()
        {
            int usercount = _userManager.Users.Count();
            return Ok(usercount);
        }
    }
}
