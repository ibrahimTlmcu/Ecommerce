using Ecommerce.Order.Application.Features.CQRS.Handlers.AddresHandlers;
using Ecommerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using Ecommerce.Order.Application.Features.CQRS.Queries.AddresQueires;
using Ecommerce.Order.Application.Features.Mediator.Handlers.OrderingHandlers;
using Ecommerce.Order.Application.Interfaces;
using Ecommerce.Order.Application.Services;
using Ecommerce.Order.Persistence.Context;
using Ecommerce.Order.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using static Ecommerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers.UpdateOrderDetailQueryHandler;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourceOrder";
    opt.RequireHttpsMetadata = false;
});


builder.Services.AddDbContext<OrderContext>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
// 2. Repository kaydý (Scoped olarak)
builder.Services.AddScoped(typeof(IOrderingRepository), typeof(OrderingRepository));
// Diðer handler'lar...
builder.Services.AddApplicationService(builder.Configuration);

// Startup.cs veya Program.cs'de


builder.Services.AddDbContext<OrderContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure());
});

builder.Services.AddScoped<GetAddressQueryHandler>();
builder.Services.AddScoped<GetAddressByIdQueryHandler>();
builder.Services.AddScoped<CreateAddressCommandHandler>();
builder.Services.AddScoped<UpdateAddressCommandHandler>();
builder.Services.AddScoped<RemoveAddressComandHandler>();

builder.Services.AddScoped<GetOrderDetailQueryHandler>();
builder.Services.AddScoped<GetOrderDetailByIdQueryHandler>();
builder.Services.AddScoped<CreateOrderDetailCommandHandler>();
builder.Services.AddScoped<UpdateOrderDetailCommandHandler>();
builder.Services.AddScoped<RemoveOrderDetailCommandHandler>();



// Add services to the container.

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
