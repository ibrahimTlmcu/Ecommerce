using Ecommerce.Discount.Context;
using Ecommerce.Discount.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];//bununla kullan
    opt.Audience = "ResourceDiscount";//config tarafinda hangi key dinleniyorsa.
    //appsett�ng �c�ne ekled�k
    //"IdentityServerUrl": "http://localhost:5001", bu serv�s�n kalktigi yer
    opt.RequireHttpsMetadata = false;
    opt.Authority = "http://localhost:5001";
});
// Add services to the container.

builder.Services.AddTransient<DapperContext>();
builder.Services.AddTransient<IDiscountService, DiscountService>();

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
