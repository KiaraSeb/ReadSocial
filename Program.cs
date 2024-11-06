using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using ReadSocial.Data; // Cambia esto según el namespace en el que definiste ApplicationDbContext


var builder = WebApplication.CreateBuilder(args);

// Agrega servicios al contenedor.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ReadSocial API", Version = "v1" });
});
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


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
    // Configura el endpoint para la documentación de Swagger
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ReadSocial API V1");

    // Cambia esto para que Swagger UI esté en una ruta específica
    c.RoutePrefix = "swagger"; // Puedes dejarlo como string.Empty para que esté en la raíz
});

// Middleware adicional
app.UseHttpsRedirection();
app.UseAuthorization();

// Mapea los controladores
app.MapControllers();

app.Run();
