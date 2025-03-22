using Ecommerce.DtoLayer.CatalogDtos.CategoryDtos;
using Ecommerce.DtoLayer.CatalogDtos.FeatureSliderDto;
using Ecommerce.WebUI.Services.CatalogServices.CategoryServices;
using Ecommerce.WebUI.ViewComponents.DefaultViewComponents;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ecommerce.WebUI.VıewComponents.DefaultViewComponents
{
    public class _CategoriesDefaultComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _CategoriesDefaultComponentPartial(ICategoryService categoryService)
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
