using Microsoft.EntityFrameworkCore;
using ReadSocial.Data;
using ReadSocial.Services;
using ReadSocial.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Habilitar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

// Agregar servicios necesarios
builder.Services.AddControllers();
builder.Services.AddScoped<IForumService, ForumService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Usar CORS
app.UseCors("AllowAllOrigins");

app.UseAuthorization();
app.MapControllers();
app.Run();

