﻿using Ecommerce.DtoLayer.BasketDtos;

namespace Ecommerce.WebUI.Services.CatalogServices.BasketServices
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasket();
        Task<BasketTotalDto> GetByUserIdBasket(string userId);
        Task SaveBasket(BasketTotalDto basketTotalDto);
        Task DeleteBasket(string userId);
        Task AddBasketItem(BasketItemDto basketItemDto);
        Task<bool> RemoveBasketItem(string productId);
    }
}
