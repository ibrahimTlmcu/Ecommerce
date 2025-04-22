using Ecommerce.DtoLayer.OrderDtos.OrderOrderingsDto;

namespace Ecommerce.WebUI.Services.CatalogServices.OrderService.OrderOrderingServices
{
    public interface IOrderOrderingService
    {
        Task<List<ResultOrderingByUserIdDto>> GetOrderingsByUserId(string id);
    }
}
