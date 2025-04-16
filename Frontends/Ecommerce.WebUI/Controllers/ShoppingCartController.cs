using Ecommerce.DtoLayer.BasketDtos;
using Ecommerce.WebUI.Services.CatalogServices.BasketServices;
using Ecommerce.WebUI.Services.CatalogServices.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {

        private readonly IProductService _productService;//productid erisim icin kullanacaz
        private readonly IBasketService _basketService;

        public ShoppingCartController(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
        }

        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]

        public async Task<IActionResult> AddBasketItem(string id)
        {
            var values = await _productService.GetByIdProduct(id);
            var items = new BasketItemDto //kontrol et !
            {
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                ProductImageUrl = values.ProductImageUrl,
                Price = values.ProductPrice,
                Quantity = 1,
               

            };
            await _basketService.AddBasketItem(items);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> RemoveBasketItem(string id)
        {
            await _basketService.RemoveBasketItem(id);
            return RedirectToAction("Index");
        }
    }
}

