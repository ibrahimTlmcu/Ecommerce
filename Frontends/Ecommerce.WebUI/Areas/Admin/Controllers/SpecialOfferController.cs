﻿
using Ecommerce.DtoLayer.CatalogDtos.SpecialOfferDtos;
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
        private readonly IHttpClientFactory _httpClientFactory;
        public SpecialOfferController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7078/api/SpecialOffer");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);
                return View(values);
            }
            //Serialeze Metinde => Jsona donusum yapiyor Ekle Guncelle daha cok 
            //Deserialeize Jsondan => Metine  Listele idye gore getir daha cok 

            return View();

        }

        [HttpGet]
        [Route("CreateSpecialOffer")]
        public IActionResult CreateSpecialOffer()
        {
            ViewBag.v0 = "Ana Sayfa";
            ViewBag.v1 = "Ozel Teklifler";
            ViewBag.v2 = "Ozel Teklifler Ve Gunun Listesi";
            ViewBag.v3 = "Kategori Islemleri";

            return View();
        }
        [HttpPost]
        [Route("CreateSpecialOffer")]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSpecialOfferDto);
            //json formatina donusturduk
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //Bir contentc olarak atadim once turu sonra dili sonra mediator
            var responseMessage = await client.PostAsync("https://localhost:7078/api/SpecialOffer", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
            }
            return View();
        }

        ///https://localhost:7078/api/SpecialOffer?id=67b5a36e3e215ab77cb6c723 api url
        //https://localhost:7165/Admin/SpecialOffer/DeleteSpecialOffer/67b4ff1dc72f143465a71977 benim gonderdigim



        [HttpPost("DeleteSpecialOffer/{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7078/api/SpecialOffer?id={id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
            }
            return View(); // Hata durumunda görünümü döndür
        }


        [Route("UpdateSpecialOffer/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7078/api/SpecialOffer/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateSpecialOfferDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [Route("UpdateSpecialOffer/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateSpecialOfferDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7078/api/SpecialOffer/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });

            }
            return View();
        }


    }
}
