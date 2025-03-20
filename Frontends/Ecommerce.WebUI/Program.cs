
using Ecommerce.WebUI.Handlers;
using Ecommerce.WebUI.Services;
using Ecommerce.WebUI.Services.CatalogServices.CategoryServices;
using Ecommerce.WebUI.Services.CatalogServices.ProductServices;
using Ecommerce.WebUI.Services.Concrate;
using Ecommerce.WebUI.Services.Interfaces;
using Ecommerce.WebUI.Settings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddCookie(JwtBearerDefaults.AuthenticationScheme,
    opt =>
    {
        opt.LoginPath = "/Login/Index";//Giris yapmayan kullanici gidecegi sayfa
        opt.LogoutPath = "/Login/Index";//Cikis yapilan sayfa
        opt.AccessDeniedPath = "/Login/Index";//Yetkisi olmayan kullanici gidecegi sayfa
        opt.ExpireTimeSpan = TimeSpan.FromMinutes(10);//Oturum suresi
        opt.Cookie.HttpOnly = true;//•	Bu ayar, çerezin sadece HTTP istekleriyle eriþilebilir olmasýný saðlar.
                                   //JavaScript gibi istemci tarafý betikleri bu çereze eriþemez
        opt.Cookie.SameSite = SameSiteMode.Strict;//•	Bu ayar, çerezin sadece ayný site içerisindeki isteklerle gönderilmesini saðlar.
                                                  //Bu, CSRF (Cross-Site Request Forgery) saldýrýlarýna karþý koruma saðlar. SameSiteMode.Strict deðeri,
                                                  //çerezin üçüncü taraf sitelerden gelen isteklerle gönderilmesini tamamen engeller.
        opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;// SameAsRequest deðeri, çerezin sadece isteðin güvenli olup olmamasýna
                                                                   // baðlý olarak gönderilmesini saðlar. Yani, HTTPS isteklerinde çerez güvenli olarak
                                                                   // iþaretlenir, HTTP isteklerinde ise güvenli olarak iþaretlenmez
        opt.Cookie.Name = "EcommerceJwt";
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



builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IIdentityService, IDentityService>();

// Add services to the container
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();


builder.Services.Configure<ClientSettings>(builder.Configuration.GetSection("ClientSettings"));
builder.Services.Configure<ServiceApiSettings>(builder.Configuration.GetSection("ServiceApiSettings"));

builder.Services.AddScoped<ResourceOwnerPasswordTokenHandler>();
builder.Services.AddScoped<ClientCredentialTokenHandler>();
builder.Services.AddScoped<IClientCredentialTokenService, ClientCredentialTokenService>();

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
    client.BaseAddress = new Uri("http://localhost:5085/services/product/"); // <-- API adresini buraya yaz!
});
builder.Services.AddHttpClient<IProductService, ProductService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();


builder.Services.AddHttpClient<ClientCredentialTokenService>();


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
