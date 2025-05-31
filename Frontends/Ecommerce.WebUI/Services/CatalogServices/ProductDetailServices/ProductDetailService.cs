using Ecommerce.DtoLayer.CatalogDtos.ProductDetailDtos;
using Newtonsoft.Json;

namespace Ecommerce.WebUI.Services.CatalogServices.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly HttpClient _httpClient;

        public ProductDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            await _httpClient.PostAsJsonAsync("productdetails", createProductDetailDto);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _httpClient.DeleteAsync($"productdetails?id={id}");
        }


        public async  Task<GetByIdProductDetailDto> GetByProductIdProductDetailAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productdetails/GetProductDetailByProductId/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductDetailDto>();
            return values;
        }
        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var response = await _httpClient.GetAsync($"productdetails/{id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<GetByIdProductDetailDto>();
            return result;
        }

       
        public async Task<List<ResultProductDetailDto>> GettAllProductDetailAsync()
        {
            var response = await _httpClient.GetAsync("productdetails");
            response.EnsureSuccessStatusCode();
            var jsonData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ResultProductDetailDto>>(jsonData);
            return result;
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            await _httpClient.PutAsJsonAsync("productdetails", updateProductDetailDto);
        }

      
        public async  Task<GetByIdProductDetailDto> GetByIdProductDetail(string id)
        {
            var response = await _httpClient.GetAsync($"productdetails/GetProductDetailByProductId/{id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<GetByIdProductDetailDto>();
            return result;
        }

      
    }
}
