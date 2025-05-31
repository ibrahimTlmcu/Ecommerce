using Ecommerce.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;



namespace Ecommerce.WebUI.Services.CatalogServices.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            await _httpClient.PostAsJsonAsync("product", createProductDto);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _httpClient.DeleteAsync($"product?id={id}");
        }

        public async Task<UpdateProductDto> GetByIdProduct(string id)
        {
            var responseMessage = await _httpClient.GetAsync("products/" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
            return values;
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var responseMessage = await _httpClient.GetAsync("products");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
            return values;
        }


        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string CategoryId)

        {
            //http://localhost:7078/api/Products/ProductListWithCategoryByCategoryId?id=67becdb06d472c011e922a44 
            var responseMessage = await _httpClient.GetAsync($"product/ProductListWithCategoryByCategoryId/{CategoryId}");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
            return values;
        }

        public async Task<List<ResultProductDto>> GettAllProductAsync()
        {
            var responseMessage = await _httpClient.GetAsync("product");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return values;
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            await _httpClient.PutAsJsonAsync("product", updateProductDto);
        }
    }
}
