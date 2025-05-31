using Ecommerce.DtoLayer.CatalogDtos.ProductDetailDtos;

namespace Ecommerce.WebUI.Services.CatalogServices.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GettAllProductDetailAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteProductDetailAsync(string id);
        Task<GetByIdProductDetailDto> GetByIdProductDetail(string id);
        Task<GetByIdProductDetailDto> GetByProductIdProductDetailAsync(string id);
    }
}
