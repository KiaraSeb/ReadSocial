using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Cargar las variables de entorno desde el archivo .env (si existe)
var environmentVariables = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddEnvironmentVariables()
    .Build();

builder.Configuration.AddConfiguration(environmentVariables);

// Validar configuraciones de JWT
if (string.IsNullOrEmpty(builder.Configuration["Jwt:Issuer"]) ||
    string.IsNullOrEmpty(builder.Configuration["Jwt:Audience"]) ||
    string.IsNullOrEmpty(builder.Configuration["Jwt:Key"]))
{
    throw new InvalidOperationException("Faltan configuraciones JWT necesarias en las variables de entorno.");
}

// Obtener la cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("cnBiblioteca");
if (string.IsNullOrEmpty(connectionString))
{
    Console.WriteLine("No se pudo encontrar la cadena de conexión 'cnBiblioteca'.");
    return;
}

// Reemplazar valores en la cadena de conexión
connectionString = connectionString.Replace("SERVER_NAME", builder.Configuration["SERVER_NAME"]);
connectionString = connectionString.Replace("DB_USER", builder.Configuration["DB_USER"]);
connectionString = connectionString.Replace("DB_PASS", builder.Configuration["DB_PASS"]);

// Configurar servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tu API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Introduce el token JWT en este formato: Bearer {token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// Configurar servicios de base de datos
builder.Services.AddSqlServer<BibliotecaContext>(connectionString);
builder.Services.AddScoped<IFileStorageService, FileStorageService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<ApplicationUser , IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Configurar autenticación JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

var app = builder.Build();

// Configuración de Swagger en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tu API v1"));
}

// Middleware de redirección HTTPS
app.UseHttpsRedirection();

// Middleware de autenticación y autorización
app.UseAuthentication();
app.UseAuthorization();

// Configurar la carpeta de frontend si es necesario
app.UseDefaultFiles(); // Permite que se busque automáticamente un archivo index.html
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "frontend")),
    RequestPath = ""
});

// Configurar el enrutamiento
app.UseRouting();
app.MapControllers(); // Mapea los controladores

// Ejecutar la aplicación
app.Run();