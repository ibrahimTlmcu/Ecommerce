﻿
namespace Ecommerce.WebUI.Services
{
    public interface ILoginService
    {
        public string GetUserId { get;  }

        Task SetAccessTokenAsync(string? accessToken);
    }
}
