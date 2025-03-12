using Ecommerce.DtoLayer.IdentityDtos;

namespace Ecommerce.WebUI.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> SignUp(SignInDto signUpDto);
    }
}
