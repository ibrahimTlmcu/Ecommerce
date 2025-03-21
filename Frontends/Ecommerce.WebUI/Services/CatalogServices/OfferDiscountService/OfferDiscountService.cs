using Ecommerce.DtoLayer.CatalogDtos.OfferDiscountDtos;
using Newtonsoft.Json;

namespace Ecommerce.WebUI.Services.CatalogServices.OfferDiscountService
{
    public class OfferDiscountService : IOfferDiscountService
    {
        private readonly HttpClient _httpClient;

        public OfferDiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _httpClient.PostAsJsonAsync("offerdiscount", createOfferDiscountDto);
        }

        public async Task DeleteOfferDiscountAsync(string id)
        {
            await _httpClient.DeleteAsync($"offerdiscount?id={id}");
        }

        public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _httpClient.PutAsJsonAsync("offerdiscount", updateOfferDiscountDto);
        }

        public async Task<List<ResultOfferDiscountDto>> GettAllOfferDiscountAsync()
        {
            var responseMessage = await _httpClient.GetAsync("offerdiscount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ResultOfferDiscountDto>>(jsonData);
        }

        public async Task<UpdateOfferDiscountDto> GetByIdOfferDiscount(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"offerdiscount/{id}");
            return await responseMessage.Content.ReadFromJsonAsync<UpdateOfferDiscountDto>();
        }

    }
}
