using Ecommerce.WebUI.Services.CatalogServices.CargoService.CargoCompanyService;
using Ecommerce.WebUI.Services.CatalogServices.CargoService.CargoCustomerServices;
using Ecommerce.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        private readonly ICargoCustomerService _cargoCustomerService;

        public UserController(IUserService userService, ICargoCustomerService cargoCustomerService)
        {
            _userService = userService;
            _cargoCustomerService = cargoCustomerService;
        }

        public async Task< IActionResult> Index()
        {
            var values = await _userService.GetUserInfo();
            return View(values);
        }
    

    }
}
