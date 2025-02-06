using Ecommerce.Order.Application.Features.CQRS.Handlers.AddresHandlers;
using Ecommerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using Ecommerce.Order.Application.Features.CQRS.Queries.AddresQueires;
using Ecommerce.Order.Application.Interfaces;
using Ecommerce.Order.Application.Services;
using Ecommerce.Order.Persistence.Context;
using Ecommerce.Order.Persistence.Repositories;
using static Ecommerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers.UpdateOrderDetailQueryHandler;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<OrderContext>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddApplicationService(builder.Configuration);



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

app.UseAuthorization();

app.MapControllers();

app.Run();
