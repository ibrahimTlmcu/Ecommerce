using Ecommerce.Catalog.Dtos.CategoryDtos;

namespace Ecommerce.Catalog.Services.CategoryServices
{
    //Ekle sil Guncelle getir gibi islemlerin metotlarini tutacak
    //CategoryService clasinin icini bu metotlarla dolduracagiz.
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GettAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string id);
        Task <UpdateCategoryDto>  GetByIdCategory(string id);
     }
}
