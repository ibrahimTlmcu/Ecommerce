
using Ecommerce.DtoLayer.CatalogDtos.OfferDiscountDtos;


namespace Ecommerce.WebUI.Services.CatalogServices.OfferDiscountService
{
    public interface IOfferDiscountService
    {
        Task<List<ResultOfferDiscountDto>> GettAllOfferDiscountAsync();
        Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto);
        Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto);
        Task DeleteOfferDiscountAsync(string id);
        Task<UpdateOfferDiscountDto> GetByIdOfferDiscount(string id);

    }

}