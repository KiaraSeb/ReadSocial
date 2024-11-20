using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.Extensions.Configuration;
using ReadSocial.Data;

var builder = WebApplication.CreateBuilder(args);

// Cargar las variables de entorno desde el archivo .env (si existe)
var environmentVariables = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory()) // Establecer el directorio de trabajo
    .AddEnvironmentVariables()                   // Cargar las variables de entorno
    .Build();

// Añadir las variables de entorno al builder de la aplicación
builder.Configuration.AddConfiguration(environmentVariables);

// Verificación de las configuraciones necesarias
if (string.IsNullOrEmpty(builder.Configuration["Jwt:Issuer"]) ||
    string.IsNullOrEmpty(builder.Configuration["Jwt:Audience"]) ||
    string.IsNullOrEmpty(builder.Configuration["Jwt:Key"]))
{
    throw new InvalidOperationException("Faltan configuraciones JWT necesarias en las variables de entorno.");
}

// Configuración de la cadena de conexión (usando las variables de entorno)
var connetionString = builder.Configuration.GetConnectionString("cnBiblioteca");
if (string.IsNullOrEmpty(connetionString))
{
    Console.WriteLine("No se pudo encontrar la cadena de conexión 'cnBiblioteca'.");
    return;
}

connetionString = connetionString.Replace("SERVER_NAME", builder.Configuration["SERVER_NAME"]);
connetionString = connetionString.Replace("DB_USER", builder.Configuration["DB_USER"]);
connetionString = connetionString.Replace("DB_PASS", builder.Configuration["DB_PASS"]);

// Agregar servicios a la aplicación
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

builder.Services.AddSqlServer<BibliotecaContext>(connetionString);
builder.Services.AddScoped<IFileStorageService, FileStorageService>();

// Configuración de Identity
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connetionString));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Configuración de JWT
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

// Construir y configurar la aplicación
var app = builder.Build();

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
