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
        opt.Cookie.HttpOnly = true;//�	Bu ayar, �erezin sadece HTTP istekleriyle eri�ilebilir olmas�n� sa�lar.
                                   //JavaScript gibi istemci taraf� betikleri bu �ereze eri�emez
        opt.Cookie.SameSite = SameSiteMode.Strict;//�	Bu ayar, �erezin sadece ayn� site i�erisindeki isteklerle g�nderilmesini sa�lar.
                                                  //Bu, CSRF (Cross-Site Request Forgery) sald�r�lar�na kar�� koruma sa�lar. SameSiteMode.Strict de�eri,
                                                  //�erezin ���nc� taraf sitelerden gelen isteklerle g�nderilmesini tamamen engeller.
        opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;// SameAsRequest de�eri, �erezin sadece iste�in g�venli olup olmamas�na
                                                                   // ba�l� olarak g�nderilmesini sa�lar. Yani, HTTPS isteklerinde �erez g�venli olarak
                                                                   // i�aretlenir, HTTP isteklerinde ise g�venli olarak i�aretlenmez
        opt.Cookie.Name = "EcommerceJwt";
    });



builder.Services.AddHttpContextAccessor();
// Bu, �zellikle ba��ml�l�k enjeksiyonu kullanarak  
// HttpContext'e eri�mek istedi�inizde faydal�d�r.

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
