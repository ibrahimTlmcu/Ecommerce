using Ecommerce.DtoLayer.IdentityDtos;
using Ecommerce.WebUI.Services.Interfaces;
using Ecommerce.WebUI.Settings;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Security.Claims;

namespace Ecommerce.WebUI.Services.Concrate
{
    public class IDentityService : IIdentityService
    {

        //Bu yapi uzerinde giris yapilacak

        private readonly HttpClient _httpClient;
        private readonly ClientSettings _clientSettings;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ServiceApiSettings _serviceApiSettings;

        public IDentityService(HttpClient httpClient, IOptions<ClientSettings> clientSettings, IHttpContextAccessor httpContextAccessor,
           IOptions<ServiceApiSettings> serviceApiSettings)
        {
            //IOptions<T>, yapılandırma ayarlarını merkezi bir yerden yönetip, bağımlılık enjeksiyonu
            //ile sınıflarınıza güvenli ve kolay bir şekilde enjekte etmenizi sağlar.
            _httpClient = httpClient;
            _clientSettings = clientSettings.Value;//Interface oldugu icin gelen degerleri aldik
            _httpContextAccessor = httpContextAccessor;
            _serviceApiSettings = serviceApiSettings.Value;
        }

        public async Task<bool> GetRefreshToken()
        {
            //bu kisim ile gelen istekleri dagitacagiz 
            var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = "http://localhost:5001",
                Policy = new DiscoveryPolicy
                {
                    RequireHttps = false,
                    //Https zorunlu olmadigi icin false dedik
                    ValidateIssuerName = false
                }

            });
       
            var refreshToken = await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);

            RefreshTokenRequest refreshTokenRequest = new RefreshTokenRequest
            {
                
                ClientId = _clientSettings.EcommerceManagerClient.ClientId,
                ClientSecret = _clientSettings.EcommerceManagerClient.ClientSecrets,
                Address = discoveryEndPoint.TokenEndpoint,
                RefreshToken = refreshToken
            };
            var token = await _httpClient.RequestRefreshTokenAsync(refreshTokenRequest);

            var authenticationToken = new List<AuthenticationToken>()
            {
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.AccessToken,
                    Value = token.AccessToken
                },
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.RefreshToken,
                    Value = token.RefreshToken
                },
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.ExpiresIn,
                    Value = DateTime.Now.AddSeconds(token.ExpiresIn).ToString()
                }
            };

            var result = await _httpContextAccessor.HttpContext.AuthenticateAsync();
            var properties = result.Properties;
            properties.StoreTokens(authenticationToken);
            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                result.Principal, properties);

            //Prop ve result null olmasina karsi if else try catch ekle
            return true;
        }

        public async Task<bool> SignUp(SignInDto signUpDto)
        {
            //bu kisim ile gelen istekleri dagitacagiz 
            var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = "http://localhost:5001",
                Policy = new DiscoveryPolicy
                {
                    RequireHttps = false,
                    //Https zorunlu olmadigi icin false dedik
                   ValidateIssuerName = false
                }

            });
            var passwordTokenRequest = new PasswordTokenRequest
            {
               
                ClientId = _clientSettings.EcommerceManagerClient.ClientId,
                ClientSecret = _clientSettings.EcommerceManagerClient.ClientSecrets,
                UserName = signUpDto.UserName,
                Password = signUpDto.Password,
                Address = discoveryEndPoint.TokenEndpoint
            };

            var token =  await _httpClient.RequestPasswordTokenAsync(passwordTokenRequest);

            var userInfoRequest = new UserInfoRequest
            {
                Token = token.AccessToken,
                Address = discoveryEndPoint.UserInfoEndpoint
            };  

            var userValeus = await _httpClient.GetUserInfoAsync(userInfoRequest);
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(userValeus.Claims, 
                CookieAuthenticationDefaults.AuthenticationScheme,"name","role");

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var authenticationProperties = new AuthenticationProperties();

            authenticationProperties.StoreTokens(new List<AuthenticationToken>
            {
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.AccessToken,
                    Value = token.AccessToken
                },
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.RefreshToken,
                    Value = token.RefreshToken
                },
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.ExpiresIn,
                    Value = DateTime.Now.AddSeconds(token.ExpiresIn).ToString()
                }
            });
            authenticationProperties.IsPersistent = true;
            //Beni hatirla degeri 
            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal
                , authenticationProperties);

            return true;
        }
    }
}

//Amac Identiy ile bu kismi haberlestirme ve bu isi rol bazli yapmaktir.
//En onemli kisim ClientId ile saglanacak
//VisitorId ManagerId 