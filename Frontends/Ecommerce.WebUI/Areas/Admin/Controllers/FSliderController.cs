
using Ecommerce.DtoLayer.CatalogDtos.FeatureSliderDto;
using Ecommerce.WebUI.Services.CatalogServices.FeatureSliderServices;
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

        private readonly IFeatureSliderService _featureSliderService;
        public FSliderController(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }
        void FeatureSliderViewBaglist()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Öne Çıkan Görseller";
            ViewBag.v3 = "Slider Öne Çıkan Görsel Listesi";
            ViewBag.v0 = "Öne Çıkan Slider Görsel İşlemleri";
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            FeatureSliderViewBaglist();
            var values = await _featureSliderService.GetAllFeatureSliderAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateFSlider")]
        public IActionResult CreateFSlider()
        {
            FeatureSliderViewBaglist();
            return View();
        }

        [HttpPost]
        [Route("CreateFSlider")]
        public async Task<IActionResult> CreateFSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
            return RedirectToAction("Index", "FSlider", new { area = "Admin" });
        }

        [Route("DeleteFSlider/{id}")]
        public async Task<IActionResult> DeleteFSlider(string id)
        {
            await _featureSliderService.DeleteFeatureSliderAsync(id);
            return RedirectToAction("Index", "FSlider", new { area = "Admin" });
        }

        [Route("UpdateFSlider/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateFSlider(string id)
        {
            FeatureSliderViewBaglist();
            var values = await _featureSliderService.GetByIdFeatureSliderAsync(id);
            return View(values);
        }

        [Route("UpdateFSlider/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateFSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {

            await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
            return RedirectToAction("Index", "FSlider", new { area = "Admin" });
        }
    }
}
