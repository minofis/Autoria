using Autoria.Core.Interfaces.Repositories;
using Autoria.Core.Interfaces;
using Autoria.Infrastructure.Data;
using Autoria.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Autoria.Core.Interfaces.Services;
using Autoria.BLL.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IBuyersRepository, BuyersRepository>();
builder.Services.AddScoped<ICartsRepository, CartsRepository>();
builder.Services.AddScoped<IVehiclesRepository, VehiclesRepository>();
builder.Services.AddScoped<IVehiclesFactory, VehiclesFactory>();
builder.Services.AddScoped<ICartsService, CartsService>();
builder.Services.AddScoped<IBuyersService, BuyersService>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddDbContext<AutoriaDbContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(AutoriaDbContext)));
});

var app = builder.Build();
app.MapControllers();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();