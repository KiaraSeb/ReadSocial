using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using DotNetEnv;

// Se agrega nuestro pequeño script para cargar las envs del archivo .env
// var root = Directory.GetCurrentDirectory();
// var dotenv = Path.Combine(root, ".env");
// DotEnv.Load(dotenv);

// Inicialización de WebApplication
var builder = WebApplication.CreateBuilder(args);

// Configuración de servicios
// Registro de Controladores
builder.Services.AddControllers();

// Se crea la cadena de conexión a partir de las variables de sistema.
var connectionString = builder.Configuration.GetConnectionString("cnForo");

// Configuración básica de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tu API", Version = "v1" });
});

// Configuración de DbContext
builder.Services.AddDbContext<ForoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("cnForo")));

// Configuración de los servicios DbService
builder.Services.AddScoped<IHiloService, HiloDbService>();
builder.Services.AddScoped<IPostService, PostDbService>();

var app = builder.Build();

// Configuración del pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Mapeo de controladores
app.MapControllers();

app.Run();
