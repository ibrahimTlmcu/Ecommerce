
using Ecommerce.DtoLayer.CatalogDtos.SpecialOfferDtos;
using Ecommerce.WebUI.Services.CatalogServices.SpecialOfferServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Ecommerce.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/SpecialOffer")]
    public class SpecialOfferController : Controller
    {
       
        private readonly ISpecialOfferServices _specialOfferServices;//// Dikkat

        public SpecialOfferController(ISpecialOfferServices? specialOfferServices)
        {
            _specialOfferServices = specialOfferServices;
        }

        void SpecialOfferViewBagList()
        {
            ViewBag.v0 = "Ana Sayfa";
            ViewBag.v1 = "Ozel Teklifler";
            ViewBag.v2 = "Ozel Teklifler Ve Gunun Listesi";
            ViewBag.v3 = "Kategori Islemleri";
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            SpecialOfferViewBagList();
            var values = await _specialOfferServices.GettAllSpecialOfferAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateSpecialOffer")]
        public IActionResult CreateSpecialOffer()
        {
          
            SpecialOfferViewBagList();
            return View();
        }
        [HttpPost]
        [Route("CreateSpecialOffer")]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _specialOfferServices.CreateSpecialOfferAsync(createSpecialOfferDto);
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }

        ///https://localhost:7078/api/SpecialOffer?id=67b5a36e3e215ab77cb6c723 api url
        //https://localhost:7165/Admin/SpecialOffer/DeleteSpecialOffer/67b4ff1dc72f143465a71977 benim gonderdigim



        [HttpPost("DeleteSpecialOffer/{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _specialOfferServices.DeleteSpecialOfferAsync(id);
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }


        [Route("UpdateSpecialOffer/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
            SpecialOfferViewBagList();
            var offer = await _specialOfferServices.GetByIdSpecialOfferAsync(id);
            return View(offer);
        }
        [Route("UpdateSpecialOffer/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _specialOfferServices.UpdateSpecialOfferAsync(updateSpecialOfferDto);
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }


    }
}
