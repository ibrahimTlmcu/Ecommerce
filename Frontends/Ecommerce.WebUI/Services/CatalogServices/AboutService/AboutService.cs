using Ecommerce.DtoLayer.CatalogDtos.AboutDtos;
using Newtonsoft.Json;
namespace Ecommerce.WebUI.Services.CatalogServices.AboutService
{
    public class AboutService : IAboutService
    {
        private readonly HttpClient _httpClient;

        public AboutService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            await _httpClient.PostAsJsonAsync("Abouts", createAboutDto);
        }

        public async Task DeleteAboutAsync(string id)
        {
            await _httpClient.DeleteAsync($"Abouts?id={id}");
        }

    

        public async Task<UpdateAboutDto> GetByIdAboutAsync(string id)
        {
            var response = await _httpClient.GetAsync($"Abouts/{id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<UpdateAboutDto>();
            return result;
        }

        public async Task<List<ResultAboutDto>> GettAllAboutAsync()
        {
            var response = await _httpClient.GetAsync("Abouts");
            response.EnsureSuccessStatusCode();
            var jsonData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
            return result;
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            await _httpClient.PutAsJsonAsync("Abouts", updateAboutDto);
        }
    }
}

