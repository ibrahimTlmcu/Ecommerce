
using Ecommerce.Catalog.Dtos.ProductDetailDtos;
using Ecommerce.Catalog.Entities;
using Ecommerce.Catalog.Mapping;
using Ecommerce.Catalog.Services.AboutServices;
using Ecommerce.Catalog.Services.BrandServices;
using Ecommerce.Catalog.Services.CategoryServices;
using Ecommerce.Catalog.Services.ContactServices;
using Ecommerce.Catalog.Services.FeatureServices;
using Ecommerce.Catalog.Services.FeatureSliderServices;
using Ecommerce.Catalog.Services.OfferDiscountService;
using Ecommerce.Catalog.Services.ProductDetailServices;
using Ecommerce.Catalog.Services.ProductImageServices;
using Ecommerce.Catalog.Services.ProductServices;
using Ecommerce.Catalog.Services.SpecialOfferServices;
using Ecommerce.Catalog.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];//bununla kullan
    opt.Audience = "ResourceCatalog";//config tarafinda hangi key dinleniyorsa.
    //appsettýng ýcýne ekledýk
    //"IdentityServerUrl": "http://localhost:5001", bu servýsýn kalktigi yer
    opt.RequireHttpsMetadata = false;// Http e cektýk bu yuzden opt ýcýnde ekledýk
});
//koruma ýcýn bearer  yapýlandýrmasý


// Add services to the container.

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();
builder.Services.AddScoped<IFeatureSliderService,FeatureSliderService>();
builder.Services.AddScoped<ISpecialOfferService, SpecialOfferService>();
builder.Services.AddScoped<IFeatureService,FeatureService>();
builder.Services.AddScoped<IOfferDiscountService, OfferDiscountService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IContactServices, ContactServices>();        




builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(typeof(GeneralMapping));


builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));//app.json icindeki keyim
builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
