using Microsoft.EntityFrameworkCore;
using ReadSocial.Data; // Asegúrate de importar el namespace de BibliotecaContext
using ReadSocial.Services;  // Para ForumService
using ReadSocial.Interfaces; // Para IForumService


var builder = WebApplication.CreateBuilder(args);

// Agrega servicios al contenedor
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "ReadSocial API", Version = "v1" });
});

// Configura el contexto de base de datos
builder.Services.AddDbContext<BibliotecaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("cnBiblioteca")));

builder.Services.AddScoped<IForumService, ForumService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ReadSocial API V1");
    c.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
