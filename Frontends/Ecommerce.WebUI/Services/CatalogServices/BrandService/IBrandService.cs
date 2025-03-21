using Ecommerce.DtoLayer.CatalogDtos.BrandDtos;

namespace Ecommerce.WebUI.Services.CatalogServices.BrandService
{
    public interface IBrandService
    {
        Task<List<ResultBrandDto>> GettAllBrandAsync();
        Task CreateBrandAsync(CreateBrandDto createBrandDto);
        Task UpdateBrandAsync(UpdateBrandDto updateBrandDto);
        Task DeleteBrandAsync(string id);
        Task<UpdateBrandDto> GetByIdBrandAsync( string id);
    }
}
