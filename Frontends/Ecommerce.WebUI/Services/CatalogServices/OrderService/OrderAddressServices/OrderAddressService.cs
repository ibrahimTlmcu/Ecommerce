using Ecommerce.DtoLayer.OrderDtos.OrderAddressDtos;

namespace Ecommerce.WebUI.Services.CatalogServices.OrderService.OrderAddressServices
{
    public class OrderAddressService : IOrderService
    {
        private readonly HttpClient _httpClient;

        public OrderAddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateOrderAddress(CreateOrderAddressDto createOrderAddressDto)
        {
            await _httpClient.PostAsJsonAsync<CreateOrderAddressDto>("addresses", createOrderAddressDto);
        }
    }
}
