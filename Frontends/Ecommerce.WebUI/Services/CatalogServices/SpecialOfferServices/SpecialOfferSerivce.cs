using Ecommerce.DtoLayer.CatalogDtos.SpecialOfferDtos;
using Newtonsoft.Json;

namespace Ecommerce.WebUI.Services.CatalogServices.SpecialOfferServices
{
    public class SpecialOfferSerivce : ISpecialOfferServices
    {
        private readonly HttpClient _httpClient;

        public SpecialOfferSerivce(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _httpClient.PostAsJsonAsync("SpecialOffer", createSpecialOfferDto);
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _httpClient.DeleteAsync($"SpecialOffer?id={id}");
        }

     

        public async Task<UpdateSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
        {
            var response = await _httpClient.GetAsync($"SpecialOffer/{id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<UpdateSpecialOfferDto>();
            return result;
        }

        public async Task<List<ResultSpecialOfferDto>> GettAllSpecialOfferAsync()
        {
            var response = await _httpClient.GetAsync("SpecialOffer");
            response.EnsureSuccessStatusCode();
            var jsonData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);
            return result;
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _httpClient.PutAsJsonAsync("specialoffer", updateSpecialOfferDto);
        }

    }
}
