using Ecommerce.DtoLayer.CatalogDtos.ProductImage;
using Newtonsoft.Json;

namespace Ecommerce.WebUI.Services.CatalogServices.ProductImageService
{
    public class ProductImageService : IProductImageService
    {
        private readonly HttpClient _httpClient;

        public ProductImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            await _httpClient.PostAsJsonAsync("poductimages", createProductImageDto);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _httpClient.DeleteAsync($"poductimages?id={id}");
        }

        public Task<GetByIdProductImageDto> GetByIdProductImage(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            var response = await _httpClient.GetAsync($"poductimages/{id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<GetByIdProductImageDto>();
            return result;
        }

        public async Task<GetByIdProductImageDto> GetByProductIdProductImageAsync(string id)
        {
            var response = await _httpClient.GetAsync($"productimages/ProductImagesByProductId/{id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<GetByIdProductImageDto>();
            return result;
        }

        public async Task<List<ResultProductImageDto>> GettAllProductImageAsync()
        {
            var response = await _httpClient.GetAsync("poductimages");
            response.EnsureSuccessStatusCode();
            var jsonData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ResultProductImageDto>>(jsonData);
            return result;
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            await _httpClient.PutAsJsonAsync("poductimages", updateProductImageDto);
        }


    }
}

