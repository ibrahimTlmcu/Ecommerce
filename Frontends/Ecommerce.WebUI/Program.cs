

using Ecommerce.Catalog.Services.SpecialOfferServices;
using Ecommerce.WebUI.Areas.Admin.Controllers;
using Ecommerce.WebUI.Handlers;
using Ecommerce.WebUI.Services;
using Ecommerce.WebUI.Services.CatalogServices.AboutService;
using Ecommerce.WebUI.Services.CatalogServices.BasketServices;
using Ecommerce.WebUI.Services.CatalogServices.BrandService;
using Ecommerce.WebUI.Services.CatalogServices.CategoryServices;
using Ecommerce.WebUI.Services.CatalogServices.FeatureSliderServices;
using Ecommerce.WebUI.Services.CatalogServices.FeautureService;
using Ecommerce.WebUI.Services.CatalogServices.OfferDiscountService;
using Ecommerce.WebUI.Services.CatalogServices.ProductDetailServices;
using Ecommerce.WebUI.Services.CatalogServices.ProductImageService;
using Ecommerce.WebUI.Services.CatalogServices.ProductServices;
using Ecommerce.WebUI.Services.CatalogServices.SpecialOfferServices;
using Ecommerce.WebUI.Services.Concrate;
using Ecommerce.WebUI.Services.Interfaces;
using Ecommerce.WebUI.Settings;
using IdentityModel.AspNetCore.AccessTokenManagement;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>

//{

//    options.MapInboundClaims = false;

//    options.Authority = builder.Configuration["IdentityServerURL"];

//    options.Audience = "ResourceBasket";

//});
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // Varsayýlan claim eþlemesini sil
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "http://localhost:5001";
        options.Audience = "EcommerceManagerId";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            NameClaimType = "sub",  // sub claim'ini NameIdentifier gibi kullan
            RoleClaimType = "role"
        };
    });



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
    AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
    {
        opt.LoginPath = "/Login/Index/";
        opt.ExpireTimeSpan = TimeSpan.FromDays(5);
        opt.Cookie.Name = "EcommerceCookie";
        opt.SlidingExpiration = true;
    });

builder.Services.AddAccessTokenManagement();
builder.Services.AddHttpContextAccessor();
// Bu, özellikle baðýmlýlýk enjeksiyonu kullanarak  
// HttpContext'e eriþmek istediðinizde faydalýdýr.
builder.Services.AddScoped<Ecommerce.WebUI.Services.CatalogServices.ProductServices.IProductService, Ecommerce.WebUI.Services.CatalogServices.ProductServices.ProductService>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IIdentityService, IDentityService>();
builder.Services.AddHttpContextAccessor();
// Add services to the container
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();
builder.Services.AddAccessTokenManagement();

builder.Services.Configure<ClientSettings>(builder.Configuration.GetSection("ClientSettings"));
builder.Services.Configure<ServiceApiSettings>(builder.Configuration.GetSection("ServiceApiSettings"));

builder.Services.AddScoped<ResourceOwnerPasswordTokenHandler>();
builder.Services.AddScoped<ClientCredentialTokenHandler>();
builder.Services.AddScoped<IClientCredentialTokenService, ClientCredentialTokenService>();
builder.Services.AddScoped<ISpecialOfferServices, SpecialOfferSerivce>();
builder.Services.AddScoped<IFeatureService, FeatureService>();
builder.Services.AddScoped<IOfferDiscountService, OfferDiscountService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();


// Service interfacten implemnete etmeyhi unutma 

var values = builder.Configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
builder.Services.AddHttpClient<IUserService, UserService>(opt =>
{
    opt.BaseAddress = new Uri("http://localhost:5001");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<ICategoryService, CategoryService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5085/services/catalog/");
})
.AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IProductService, ProductService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5085/services/catalog/"); // <-- API adresini buraya yaz!
}).AddHttpMessageHandler<ClientCredentialTokenHandler>(); ;

builder.Services.AddHttpClient<ISpecialOfferServices, SpecialOfferSerivce>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5085/services/catalog/"); // <-- API adresini buraya yaz!
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IFeatureSliderService, FeatureSliderService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5085/services/catalog/"); // <-- API adresini buraya yaz!
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IFeatureService, FeatureService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5085/services/catalog/"); // <-- API adresini buraya yaz!
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();


// Service interfacten implemnete etmeyhi unutma 
builder.Services.AddHttpClient<IOfferDiscountService, OfferDiscountService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5085/services/catalog/"); // <-- API adresini buraya yaz!
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IBrandService, BrandService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
    //client.BaseAddress = new Uri("http://localhost:5085/services/catalog/"); // <-- API adresini buraya yaz!
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IAboutService, AboutService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
    //client.BaseAddress = new Uri("http://localhost:5085/services/catalog/"); // <-- API adresini buraya yaz!
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();


builder.Services.AddHttpClient<IProductImageService, ProductImageService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
    //client.BaseAddress = new Uri("http://localhost:5085/services/catalog/"); // <-- API adresini buraya yaz!
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IProductDetailService, ProductDetailService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
    //client.BaseAddress = new Uri("http://localhost:5085/services/catalog/"); // <-- API adresini buraya yaz!
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();



// Doðru HttpClient konfigürasyonu:
builder.Services.AddHttpClient<IBasketService, BasketService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:7246/api/");
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.Configure<ClientSettings>(builder.Configuration.GetSection("ClientSettings"));
builder.Services.Configure<ServiceApiSettings>(builder.Configuration.GetSection("ServiceApiSettings"));
builder.Services.AddSingleton<IClientAccessTokenCache, ClientAccessTokenCache>();
builder.Services.AddScoped<IClientCredentialTokenService, ClientCredentialTokenService>();


builder.Services.AddHttpContextAccessor();

builder.Services.AddHttpClient<ClientCredentialTokenService>();


// Service interfacten implemnete etmeyhi unutma 

builder.Services.AddTransient<ClientCredentialTokenHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});



app.Run();
