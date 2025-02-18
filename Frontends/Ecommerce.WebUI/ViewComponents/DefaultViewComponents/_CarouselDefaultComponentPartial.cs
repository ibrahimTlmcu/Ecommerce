
using Ecommerce.Catalog.Dtos.FeatureSliderDtos;

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ecommerce.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CarouselDefaultComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

      

        private readonly ILogger<_CarouselDefaultComponentPartial> _logger;

        public _CarouselDefaultComponentPartial(IHttpClientFactory httpClientFactory, ILogger<_CarouselDefaultComponentPartial> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7078/api/FeatureSliders");
            Console.WriteLine("Metot çalıştı!");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);
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
