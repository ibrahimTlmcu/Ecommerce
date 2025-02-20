using Ecommerce.DtoLayer.CatalogDtos.OfferDiscountDtos;
using Ecommerce.WebUI.ViewComponents.DefaultViewComponents;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace Ecommerce.WebUI.VıewComponents.DefaultViewComponents
{
    public class _OfferDiscountDefaultComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<_CarouselDefaultComponentPartial> _logger;

        public _OfferDiscountDefaultComponentPartial(IHttpClientFactory httpClientFactory, ILogger<_CarouselDefaultComponentPartial> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7078/api/OfferDiscount");
            Console.WriteLine("Metot çalıştı!");  
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultOfferDiscountDto>>(jsonData);
                return View(values);
            }
            else
            {
                _logger.LogError("API Hatası: {StatusCode}", responseMessage.StatusCode);
            }
            return View();
        }
    }
}
