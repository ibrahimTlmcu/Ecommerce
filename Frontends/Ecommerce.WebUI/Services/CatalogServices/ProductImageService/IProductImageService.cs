using Ecommerce.DtoLayer.CatalogDtos.ProductImage;

namespace Ecommerce.WebUI.Services.CatalogServices.ProductImageService
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GettAllProductImageAsync();
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImageAsync(string id);
        Task<GetByIdProductImageDto> GetByIdProductImage(string id);
        Task<GetByIdProductImageDto> GetByProductIdProductImageAsync(string id);
    }
}
