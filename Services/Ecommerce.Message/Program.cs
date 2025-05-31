using Ecommerce.Message.DAL.Context;
using Ecommerce.Message.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];//bununla kullan
    opt.Audience = "ResoruceMessage";//config tarafinda hangi key dinleniyorsa.
    //appsettýng ýcýne ekledýk
    //"IdentityServerUrl": "http://localhost:5001", bu servýsýn kalktigi yer
    opt.RequireHttpsMetadata = false;
    opt.Authority = "http://localhost:5001";
});

builder.Services.AddScoped<IUserMessageService,UserMessageService>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
// Add services to the container.
builder.Services.AddDbContext<MessageContext>(opt =>
{
    opt.UseNpgsql(connectionString);
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
