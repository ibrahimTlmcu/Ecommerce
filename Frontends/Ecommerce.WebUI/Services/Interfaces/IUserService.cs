using Ecommerce.WebUI.Models;

namespace Ecommerce.WebUI.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDetailViewModel> GetUserInfo();
    }
}
