using Ecommerce.WebUI.Services.Interfaces;
using Ecommerce.WebUI.Settings;
using IdentityModel.AspNetCore.AccessTokenManagement;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Ecommerce.WebUI.Services.Concrate
{
    [AllowAnonymous]
    public class ClientCredentialTokenService : IClientCredentialTokenService
    {
        private readonly ServiceApiSettings _serviceApiSettings;
        private readonly HttpClient _httpClient;
        private readonly IClientAccessTokenCache _clientAccessTokenCache;
        private readonly ClientSettings _clientSettings;

        public ClientCredentialTokenService(IOptions<ServiceApiSettings> serviceApiSettings, HttpClient httpClient, IClientAccessTokenCache clientAccessTokenCache, IOptions<ClientSettings> clientSettings)
        {
            _serviceApiSettings = serviceApiSettings.Value;
            _httpClient = httpClient;
            _clientAccessTokenCache = clientAccessTokenCache;
            _clientSettings = clientSettings.Value;
        }

        public async Task<string> GetToken()
        {
            var token1 = await _clientAccessTokenCache.GetAsync("ecommercetoken");
            if (token1 != null)
            {
                return token1.AccessToken;
            }
            var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = "http://localhost:5001",
                Policy = new DiscoveryPolicy
                {
                    RequireHttps = false
                }
            });

            var clientCredentialTokenRequest = new ClientCredentialsTokenRequest
            {
                ClientId = _clientSettings.EcommerceVisitorClient.ClientId,
                ClientSecret = _clientSettings.EcommerceVisitorClient.ClientSecrets,
                Address = discoveryEndPoint.TokenEndpoint
            };


            var token2 = await _httpClient.RequestClientCredentialsTokenAsync(clientCredentialTokenRequest); //hata burda
            await _clientAccessTokenCache.SetAsync("ecommercetoken", token2.AccessToken, token2.ExpiresIn);
            return token2.AccessToken;
        }//Porgram.cs icinde registration yapilacak \

    }
}