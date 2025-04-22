using Ecommerce.DtoLayer.OrderDtos.OrderOrderingsDto;
using Newtonsoft.Json;

namespace Ecommerce.WebUI.Services.CatalogServices.OrderService.OrderOrderingServices
{
    public class OrderOrderingService : IOrderOrderingService
    {
        private readonly HttpClient _httpClient;
public OrderOrderingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultOrderingByUserIdDto>> GetOrderingsByUserId(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"ordering/GetOrderingsByUserId/{id}");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values  = JsonConvert.DeserializeObject<List<ResultOrderingByUserIdDto>>(jsonData);
            return values;
        }
    }
}
