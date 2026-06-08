using Avia.BusinessLogicLayer.Interfaces;
using Avia.BusinessLogicLayer.Mapper;
using Avia.BusinessLogicLayer.Services;
using Avia.DataAccessLayer.Interfaces;
using Avia.DataAccessLayer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddTransient<ICityService, CityService>();
builder.Services.AddTransient<IAirportService, AirportService>();
builder.Services.AddTransient<ICityRepository, CityRepository>();
builder.Services.AddTransient<IAirportRepository, AirportRepository>();

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

public partial class Program { }
