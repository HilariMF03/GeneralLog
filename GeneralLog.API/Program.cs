using GeneralLog.Application.Interfaces;
using GeneralLog.Application.Services;
using GeneralLog.Infrastructure.Configurations;
using GeneralLog.Infrastructure.Database;
using GeneralLog.Infrastructure.Repositories;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Configurar MongoDB desde appsettings.json
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.AddSingleton<MongoDbContext>();

// Registrar el servicio con su interfaz
builder.Services.AddScoped<ILogService, LogService>();

// Registrar el repositorio
builder.Services.AddScoped<ILogRepository, LogRepository>();

// Registrar LogService
builder.Services.AddScoped<LogService>();

// Habilitar controladores
builder.Services.AddControllers();

// Agregar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "GeneralLog API",
        Version = "v1"
    });
});

var app = builder.Build();

// Habilitar Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "GeneralLog API v1");
        c.RoutePrefix = string.Empty; // Hace que Swagger esté en la raíz del servidor
    });
}

app.UseHttpsRedirection();


app.MapControllers();

app.Run();
