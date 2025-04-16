using Microsoft.AspNetCore.Mvc;
using Ecommerce.DtoLayer.IdentityDtos.LoginDtos;

using System.Text;
using System.Text.Json;
using Ecommerce.WebUI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Ecommerce.WebUI.Services;
using Ecommerce.WebUI.Services.Interfaces;
using Ecommerce.DtoLayer.IdentityDtos;
namespace Ecommerce.WebUI.Controllers
{

    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IIdentityService _identityService;
        public LoginController(IHttpClientFactory httpClientFactory, IIdentityService identityService)
        {
            _httpClientFactory = httpClientFactory;
            _identityService = identityService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SignInDto signInDto)
        {
            await _identityService.SignUp(signInDto);
            return RedirectToAction("Index", "User");
        }
    }
}
