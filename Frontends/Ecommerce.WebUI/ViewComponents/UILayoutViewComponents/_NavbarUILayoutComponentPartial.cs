using Ecommerce.DtoLayer.CatalogDtos.CategoryDtos;
using Ecommerce.WebUI.Services.CatalogServices.CategoryServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ecommerce.WebUI.VıewComponents.UILayoutViewComponents
{
    public class _NavbarUILayoutComponentPartial : ViewComponent
    {

        private readonly ICategoryService _categoryService;

        public _NavbarUILayoutComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var values = await _categoryService.GettAllCategoryAsync();
            return View(values);
        }

    }
}
 