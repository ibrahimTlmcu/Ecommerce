using Ecommerce.DtoLayer.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Ecommerce.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index(string id)
        {
            //Bu id Kategori icinden geliyor
            ViewBag.i = id;
            return View();
        }

        public IActionResult ProductDetail(string id )
        {
            ViewBag.x = id;
            return View();
        }

        [HttpGet]
        public PartialViewResult AddComment(string id)
        {
            return PartialView();
        }

        [HttpPost]

        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
        {
            createCommentDto.ImageUrl = "test";
            createCommentDto.Rating = 1;
            createCommentDto.CreateDate =DateTime.Parse( DateTime.Now.ToShortDateString());
            createCommentDto.Status = false;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCommentDto);
            //json formatina donusturduk
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //Bir contentc olarak atadim once turu sonra dili sonra mediator
            var responseMessage = await client.PostAsync("https://localhost:7130/api/Comments?id=", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default", new { area = "Admin" });
            }
            return View();
        }



    }
}
