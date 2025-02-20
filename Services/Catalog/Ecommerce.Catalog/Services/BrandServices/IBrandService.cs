using Ecommerce.Catalog.Dtos.BrandDtos;

namespace Ecommerce.Catalog.Services.BrandServices
{
    public interface IBrandService
    {
        Task<List<ResultBrandDto>> GettAllBrandAsync();
        Task CreateBrandAsync(CreateBrandDto createBrandDto);
        Task UpdateBrandAsync(UpdateBrandDto updateBrandDto);
        Task DeleteBrandAsync(string id);
        Task<GetByIdBrandDto> GetByIdBrand(string id);
    }
}
