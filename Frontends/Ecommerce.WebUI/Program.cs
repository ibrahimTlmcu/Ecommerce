using Ecommerce.WebUI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;

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



builder.Services.AddHttpContextAccessor();
// Bu, özellikle baðýmlýlýk enjeksiyonu kullanarak  
// HttpContext'e eriþmek istediðinizde faydalýdýr.

builder.Services.AddScoped<ILoginService, LoginService>();

// Add services to the container
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();

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
