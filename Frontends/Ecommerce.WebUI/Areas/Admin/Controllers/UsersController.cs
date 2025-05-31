using Ecommerce.WebUI.Services.CatalogServices.CargoService.CargoCustomerServices;
using Ecommerce.WebUI.Services.CatalogServices.UserIdentityServices;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IUserIdentityService _userIdentityService;
        private readonly ICargoCustomerService _cargoCustomerService;

        public UsersController(IUserIdentityService userIdentityService, ICargoCustomerService cargoCustomerService)
        {
            _userIdentityService = userIdentityService;
            _cargoCustomerService = cargoCustomerService;
        }

        public async Task<IActionResult> UserListAsync()
        {
            var values = await _userIdentityService.GetAllUserListAsync();
            return View(values);
        }

        public async Task<IActionResult> UserAddressInfo(string id)
        {
            var values = await _cargoCustomerService.GetByIdCargoCustomerInfoAsync(id);
            return View(values);
        }
    }
}
