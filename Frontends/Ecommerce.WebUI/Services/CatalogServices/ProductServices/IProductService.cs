
using Ecommerce.DtoLayer.CatalogDtos.ProductDtos;


namespace Ecommerce.WebUI.Services.CatalogServices.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GettAllProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<UpdateProductDto> GetByIdProduct(string id); 
        Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync();
        Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string CategoryId);
    }
}
