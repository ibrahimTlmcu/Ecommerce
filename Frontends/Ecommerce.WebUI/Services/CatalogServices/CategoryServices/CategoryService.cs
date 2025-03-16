using Ecommerce.DtoLayer.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;

namespace Ecommerce.WebUI.Services.CatalogServices.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            await _httpClient.PostAsJsonAsync("categories", createCategoryDto);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _httpClient.DeleteAsync($"categories?id={id}");
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var response = await _httpClient.GetAsync($"categories/{id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<GetByIdCategoryDto>();
            return result;
        }

        public async Task<List<ResultCategoryDto>> GettAllCategoryAsync()
        {
            var response = await _httpClient.GetAsync("categories");
            response.EnsureSuccessStatusCode();
            var jsonData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            return result;
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            await _httpClient.PutAsJsonAsync("categories", updateCategoryDto);
        }

        Task<UpdateCategoryDto> ICategoryService.GetByIdCategoryAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
