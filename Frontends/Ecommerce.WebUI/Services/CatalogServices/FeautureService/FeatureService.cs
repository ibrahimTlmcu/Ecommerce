using Ecommerce.DtoLayer.CatalogDtos.FeatureDtos;
using Newtonsoft.Json;

namespace Ecommerce.WebUI.Services.CatalogServices.FeautureService
{
    public class FeatureService : IFeatureService
    {
        private readonly HttpClient _httpClient;

        public FeatureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            await _httpClient.PostAsJsonAsync("feature", createFeatureDto);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _httpClient.DeleteAsync($"feature?id={id}");
        }

      

        public async Task<UpdateFeatureDto> GetByIdFeatureAsync(string id)
        {
            var response = await _httpClient.GetAsync($"feature/{id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<UpdateFeatureDto>();
            return result;
        }
        public async  Task<List<ResultFeatureDto>> GetAllFeatureAsync()
        {
            var response = await _httpClient.GetAsync("features");
            response.EnsureSuccessStatusCode();
            var jsonData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
            return result;
        }
       

        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            await _httpClient.PutAsJsonAsync("feature", updateFeatureDto);
        }
    }
}
