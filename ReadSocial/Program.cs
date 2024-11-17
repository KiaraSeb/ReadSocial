using Microsoft.EntityFrameworkCore;
using ReadSocial.Data;
using ReadSocial.Services;
using ReadSocial.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Configura los servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BibliotecaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("cnBiblioteca")));
builder.Services.AddScoped<IForumService, ForumService>();

var app = builder.Build();

// Configura la tubería de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
