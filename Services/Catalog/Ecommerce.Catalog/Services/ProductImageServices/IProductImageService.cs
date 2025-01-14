using Ecommerce.Catalog.Dtos.ProductImageDto;


namespace Ecommerce.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GettAllProductImageAsync();
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImageAsync(string id);
        Task<GetByIdProductImageDto> GetByIdProductImage(string id);
    }
}
