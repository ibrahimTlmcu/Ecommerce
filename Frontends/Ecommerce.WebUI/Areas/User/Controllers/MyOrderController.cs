using Ecommerce.WebUI.Services.CatalogServices.OrderService.OrderOrderingServices;
using Ecommerce.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecommerce.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MyOrderController : Controller
    {
        private readonly IOrderOrderingService _orderingSerive;
        private readonly IUserService _userService;

        public MyOrderController(IOrderOrderingService orderingSerive, IUserService userService)
        {
            _orderingSerive = orderingSerive;
            _userService = userService;
        }

        public async Task<IActionResult> MyOrderList()
        {
           var user = await _userService.GetUserInfo();
           
            var values = await _orderingSerive.GetOrderingsByUserId(user.Id);
            return View(values);
        }
    }
}
