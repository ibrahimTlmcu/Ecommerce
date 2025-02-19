
using Ecommerce.DtoLayer.CatalogDtos.FeatureSliderDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Ecommerce.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/FSlider")]
    public class FSliderController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public FSliderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        [AllowAnonymous]
       
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7078/api/FeatureSliders");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine("API'den Gelen JSON: " + jsonData); // Konsola yazdır

                var values = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);

                if (values == null || !values.Any())
                {
                    Console.WriteLine("API'den dönen veri listesi boş.");
                }

                return View(values);
            }

            Console.WriteLine("API çağrısı başarısız oldu.");
            return View(new List<ResultFeatureSliderDto>());
        }

        [HttpGet]
        [Route("CreateFSlider")]
        public IActionResult CreateFSlider()
        {
            ViewBag.v0 = "Kategori İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Kategori Listesi";

            return View();
        }
        [HttpPost]
        [Route("CreateFSlider")]
        public async Task<IActionResult> CreateFSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createFeatureSliderDto);
            //json formatina donusturduk
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //Bir contentc olarak atadim once turu sonra dili sonra mediator
            var responseMessage = await client.PostAsync("https://localhost:7078/api/FeatureSliders", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FSlider", new { area = "Admin" });
            }
            return View();
        }
   
        [Route("{id}")]
        public async Task<IActionResult> DeleteFSlider(string id)
        {
            var client = _httpClientFactory.CreateClient();

            // URL'yi ?id={id} formatına göre oluştur
            var responseMessage = await client.DeleteAsync($"https://localhost:7078/api/FeatureSliders?id={id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FSlider", new { area = "Admin" });
            }

            return View();
        }


        [Route("UpdateFSlider/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateFSlider(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7078/api/FeatureSliders/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateFeatureSliderDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [Route("UpdateFSlider/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateFSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateFeatureSliderDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7078/api/FeatureSliders/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index", "FSlider", new { area = "Admin" });

            }
            return View();
        }
    }
}
