using Ecommerce.DtoLayer.OrderDtos.OrderAddressDtos;
using Ecommerce.WebUI.Services.CatalogServices.OrderService.OrderAddressServices;
using Ecommerce.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecommerce.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;

        public OrderController(IOrderService orderService, IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }   

        [HttpPost]
        public async Task<IActionResult> Index(CreateOrderAddressDto createOrderAddressDto)
        {
            var values = await _userService.GetUserInfo();
            createOrderAddressDto.UserId = values.Id;
            createOrderAddressDto.Description = " Address"; 
            await _orderService.CreateOrderAddress(createOrderAddressDto);
            return RedirectToAction("Index", "Payment");

        }
    }
}
