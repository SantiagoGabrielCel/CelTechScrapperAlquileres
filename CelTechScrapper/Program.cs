
using Aplicacion.CasosDeUso.CalcularConectividad;
using Aplicacion.Servicios;
using CelTechScrapper.Aplicacion.Servicios.Geolocalizador;
using CelTechScrapper.CasosDeUso.ObtenerIndiceSaturacion;
using CelTechScrapper.Aplicacion.CasosDeUso.ObtenerPropiedades;
using CelTechScrapper.CasosDeUso.SimuladorDeAlquiler;
using CelTechScrapper.Infraestructura.ServiciosGeolocalizacion;
using CelTechScrapper.Infraestructura.ServiciosScraper;
using Infraestructura.ServiciosConectividad;
using Infraestructura.ServiciosOverpass;
using WebApi.Controladores;

var builder = WebApplication.CreateBuilder(args);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Controladores
builder.Services.AddControllers();

// Inyecci�n de dependencias
builder.Services.AddScoped<IPropiedadScraperService, ArgenpropScraperService>();
builder.Services.AddScoped<ManejadorObtenerPropiedades>();
builder.Services.AddScoped<ManejadorSimuladorAlquiler>();
builder.Services.AddScoped<ManejadorIndiceSaturacion>();
builder.Services.AddScoped<IGeolocalizacionService, GeolocalizacionService>();
builder.Services.AddScoped<IConectividadService, ConectividadService>();
builder.Services.AddScoped<ManejadorConectividad>();
builder.Services.AddScoped<IOverpassService, OverpassService>();
var app = builder.Build();

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();
app.UseAuthorization();

app.MapControllers();
app.Run();
