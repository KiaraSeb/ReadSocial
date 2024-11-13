using ReadSocial.Services;  // Asegúrate de importar el espacio de nombres de ForumService
using ReadSocial.Interfaces; // Asegúrate de importar el espacio de nombres de IForumService

var builder = WebApplication.CreateBuilder(args);

// Agrega servicios al contenedor.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "ReadSocial API", Version = "v1" });
});

// Registrar ForumService como IForumService
builder.Services.AddScoped<IForumService, ForumService>();

var app = builder.Build();

// Configura la tubería de solicitudes HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Habilita Swagger y el Swagger UI
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ReadSocial API V1");
    c.RoutePrefix = string.Empty;  // Cambia esto si deseas que Swagger UI esté en una ruta específica
});

// Middleware adicional
app.UseHttpsRedirection();
app.UseAuthorization();

// Mapea los controladores
app.MapControllers();

app.Run();
