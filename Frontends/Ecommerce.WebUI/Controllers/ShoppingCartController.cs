using Ecommerce.DtoLayer.BasketDtos;
using Ecommerce.WebUI.Services.CatalogServices.BasketServices;
using Ecommerce.WebUI.Services.CatalogServices.DiscountService;
using Ecommerce.WebUI.Services.CatalogServices.ProductServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecommerce.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {

        private readonly IProductService _productService;//productid erisim icin kullanacaz
        private readonly IBasketService _basketService;
        private readonly IDiscountService _discountService;

        public ShoppingCartController(IProductService productService, IBasketService basketService, IDiscountService discountService)
        {
            _productService = productService;
            _basketService = basketService;
            _discountService = discountService;
        }

        public async Task<IActionResult> Index(string code , int discountRate,decimal totalNewPriceWithDiscount)
        {
            ViewBag.code = code;
            ViewBag.discountRate = discountRate;
            ViewBag.totalNewPriceWithDiscount = totalNewPriceWithDiscount;
            var values = await _basketService.GetBasket();
            ViewBag.total = values.TotalPrice;
            var totalPriceWithTax = values.TotalPrice + values.TotalPrice / 100 * 10;
            var tax = values.TotalPrice / 100 * 10;
            ViewBag.totalPriceWithTax = totalPriceWithTax; 
            ViewBag.tax = tax;  

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

