using Ecommerce.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Net;
using System.Net.Http.Headers;

namespace Ecommerce.WebUI.Handlers
{
    public class ResourceOwnerPasswordTokenHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IIdentityService _identityServer;

        public ResourceOwnerPasswordTokenHandler(IHttpContextAccessor httpContextAccessor, IIdentityService identityServer)
        {
            _httpContextAccessor = httpContextAccessor;
            _identityServer = identityServer;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
           var accesToken = await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken); 
           request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accesToken);
           var response = await base.SendAsync(request, cancellationToken);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var tokenResponse = await _identityServer.GetRefreshToken();

                if(tokenResponse != null)
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accesToken);
                    response = await base.SendAsync(request, cancellationToken);
                }
            }
            if(response.StatusCode == HttpStatusCode.Unauthorized)
            {
                //
            }
            return response;
        }
    }
}
