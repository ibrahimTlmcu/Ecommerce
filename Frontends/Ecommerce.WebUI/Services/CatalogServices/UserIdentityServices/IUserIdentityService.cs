using Ecommerce.DtoLayer.IdentityDtos.UsersDtos;

namespace Ecommerce.WebUI.Services.CatalogServices.UserIdentityServices
{
    public interface IUserIdentityService
    {
        Task<List<ResultUsersDtos>> GetAllUserListAsync();
    }
}
