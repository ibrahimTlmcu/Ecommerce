using Ecommerce.DtoLayer.CatalogDtos.SpecialOfferDtos;

namespace Ecommerce.WebUI.Services.CatalogServices.SpecialOfferServices
{
    public interface ISpecialOfferServices
    {

        Task<List<ResultSpecialOfferDto>> GettAllSpecialOfferAsync();
        Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto);
        Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto);
        Task DeleteSpecialOfferAsync(string id);
        Task<UpdateSpecialOfferDto> GetByIdSpecialOfferAsync(string id);
    }
}
