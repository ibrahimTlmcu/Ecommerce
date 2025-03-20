using Ecommerce.DtoLayer.CatalogDtos.CategoryDtos;

namespace Ecommerce.WebUI.Services.CatalogServices.CategoryServices
{
    public interface ICategoryService
    {

        Task<List<ResultCategoryDto>> GettAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string id);
        Task<UpdateCategoryDto> GetByIdCategoryAsync(string id);
    }
}
