using Ecommerce.DtoLayer.IdentityDtos.UsersDtos;
using Ecommerce.WebUI.Services.CatalogServices.UserIdentityServices;
using Newtonsoft.Json;

namespace Ecommerce.WebUI.Services.CatalogServices.UserIdentityService
{
    public class UserIdentityService : IUserIdentityService
    {
        private readonly HttpClient _httpClient;
        public UserIdentityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ResultUsersDtos>> GetAllUserListAsync()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5001/api/user/GetAllUserList");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultUsersDtos>>(jsonData);
            return values;
        }
    }
}
