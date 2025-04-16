using Ecommerce.Basket.LoginServices;
using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

public class LoginService : ILoginService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public LoginService(IHttpContextAccessor contextAccessor)
    {
        _httpContextAccessor = contextAccessor;
    }

    public string GetUserId => _httpContextAccessor.HttpContext.User.FindFirst("sub").Value;

}