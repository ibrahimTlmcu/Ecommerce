using Ecommerce.Order.Application.Features.CQRS.Handlers.AddresHandlers;
using Ecommerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using Ecommerce.Order.Application.Features.CQRS.Queries.AddresQueires;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<GetAddressByIdQuery>();
builder.Services.AddScoped<GetAddressByIdQueryHandler>();
builder.Services.AddScoped<CreateAddressCommandHandler>();
builder.Services.AddScoped<UpdateAddressCommandHandler>();
builder.Services.AddScoped<RemoveAddressComandHandler>();

builder.Services.AddScoped<GetOrderDetailQueryHandler>();
builder.Services.AddScoped<GetOrderDetailByIdQueryHandler>();
builder.Services.AddScoped<CreateOrderDetailCommandHandler>();
builder.Services.AddScoped<UpdateOrderDetailQueryHandler>();
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
