using Ecommerce.DtoLayer.DiscountDtos;

namespace Ecommerce.WebUI.Services.CatalogServices.DiscountService
{
    
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetDiscountCodeDetailByCode> GetDiscountCode(string code)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7273/api/Discounts/" +
                "GetCodeDetailByCodeAsync?code=" + code );
            //mikroservis tarafina istekte buluancagiuz

            var values = await responseMessage.Content.ReadFromJsonAsync<GetDiscountCodeDetailByCode>();
            return values;
             

        }

        public Task<int> GetDiscountCouponCountRateAsync(string code)
        {
            var responseMessage = _httpClient.GetAsync("http://localhost:7273/api/Discounts/" +
                "GetDiscountCouponCountRateAsync?code=" + code); 
            var values = responseMessage.Result.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
     