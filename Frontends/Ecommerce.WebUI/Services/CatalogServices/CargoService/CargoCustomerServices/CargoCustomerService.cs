using Ecommerce.DtoLayer.CargoDtos;

namespace Ecommerce.WebUI.Services.CatalogServices.CargoService.CargoCustomerServices
{
    public class CargoCustomerService : ICargoCustomerService
    {
        private readonly HttpClient _httpClient;
        public CargoCustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<GetCargoCustomerByIdDto> GetByIdCargoCustomerInfoAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7190/api/CargoCustomers/GetCargoCustomerById?id=" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetCargoCustomerByIdDto>();
            return values;
        }
    }
    
}