using Autoria.Core.Interfaces.Repositories;
using Autoria.Infrastructure.Data;
using Autoria.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Autoria.Core.Interfaces.Services;
using Autoria.BLL.Services;
using Autoria.Core.Interfaces.Factories;
using Autoria.Core.Factories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IBuyersRepository, BuyersRepository>();
builder.Services.AddScoped<IFavoritesListsRepository, FavoritesListsRepository>();
builder.Services.AddScoped<IVehiclesRepository, VehiclesRepository>();
builder.Services.AddScoped<IFavoritesListsService, FavoritesListsService>();
builder.Services.AddScoped<IBuyersService, BuyersService>();
builder.Services.AddScoped<IVehiclesService, VehiclesService>();
builder.Services.AddScoped<IVehiclesFactory, VehiclesFactory>();
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