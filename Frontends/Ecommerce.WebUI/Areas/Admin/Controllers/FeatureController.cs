using Ecommerce.DtoLayer.CatalogDtos.FeatureDtos;
using Ecommerce.WebUI.Services.CatalogServices.FeautureService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Ecommerce.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Feature")]
    public class FeatureController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        private readonly IFeatureService _FeaturesService;
        public FeatureController(IHttpClientFactory httpClientFactory, IFeatureService FeaturesService)
        {
            _httpClientFactory = httpClientFactory;
            _FeaturesService = FeaturesService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {

            var values = await _FeaturesService.GetAllFeatureAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateFeature")]
        public IActionResult CreateFeature()
        {
            FeaturesViewBagList();
            return View();
        }

        [HttpPost]
        [Route("CreateFeature")]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeaturesDto)
        {

            await _FeaturesService.CreateFeatureAsync(createFeaturesDto);
            return RedirectToAction("Index", "Feature", new { area = "Admin" });
        }

        [Route("DeleteFeature/{id}")]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            await _FeaturesService.DeleteFeatureAsync(id);
            return RedirectToAction("Index", "Feature", new { area = "Admin" });
        }

        [Route("UpdateFeature/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateFeature(string id)
        {
            FeaturesViewBagList();
            var Features = await _FeaturesService.GetByIdFeatureAsync(id);
            return View(Features);

        }
        [Route("UpdateFeature/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeaturesDto)
        {
            await _FeaturesService.UpdateFeatureAsync(updateFeaturesDto);
            return RedirectToAction("Index", "Feature", new { area = "Admin" });
        }

        void FeaturesViewBagList()
        {

            ViewBag.v0 = "Kategori İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Kategori Listesi";
        }

    }
}
