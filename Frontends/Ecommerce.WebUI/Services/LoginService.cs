using System.Security.Claims;

namespace Ecommerce.WebUI.Services
{
    using System.IdentityModel.Tokens.Jwt;
    using System.Threading.Tasks;

    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public LoginService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public string? GetUserId => _contextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        public Task SetAccessTokenAsync(string? accessToken)
        {
            throw new NotImplementedException();
        }
    }
}
