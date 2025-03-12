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
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly ILoginService _loginService;

        private readonly IIdentityService _identityService;
 
        public LoginController(IHttpClientFactory httpClientFactory, ILoginService loginService,
            IIdentityService identityService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
            _identityService = identityService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult>Index(CreateLoginDto createLoginDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonSerializer.Serialize(createLoginDto),Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5001/api/Login", content);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
                //response.Content.ReadAsStringAsync() metodu, HTTP yanıt içeriğini bir dize olarak okur ve JsonSerializer.Deserialize<JwtResponseModel> metodu, bu dizeyi JwtResponseModel türüne dönüştürür.
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
                if (tokenModel != null)
                {
                    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.ReadJwtToken(tokenModel.Token);
                    var claims = token.Claims.ToList();
                    if(tokenModel.Token != null)
                    {
                        claims.Add(new Claim("ecommercetoken", tokenModel.Token));
                        var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties
                        {
                            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                            IsPersistent = true
                        };

                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                        var id = _loginService.GetUserId;
                        return RedirectToAction("Index", "Default");
                    }
                } 
            }
            return View();
        }



        //[HttpGet]

        //public IActionResult SignUp()
        //{
        //    return View();
        //}

        public async Task<IActionResult> SignUp(SignInDto signUpDto)
        {
            signUpDto.UserName = "aahm1234";
            signUpDto.Password = "12345678aA/";
            await _identityService.SignUp(signUpDto);
            return RedirectToAction("Index", "Test");
            
        }
    }

}
