using HAIS.Backend.Models;
using HAIS.Backend.Services; // Make sure this matches the namespace of your OpenProjectOptions class
using OpenProjectService = HAIS.Backend.Services.OpenProjectService;
var builder = WebApplication.CreateBuilder(args);

// 🔹 Register OpenProject options from configuration
builder.Services.Configure<OpenProjectOptions>(
    builder.Configuration.GetSection("OpenProject"));

// 🔹 CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp", policy =>
    {
        policy.WithOrigins("http://localhost:8080") // Default port for Vite
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// 🔹 Add controllers
builder.Services.AddControllers();


// 🔹 Add HttpClient support for OpenProjectService
builder.Services.AddHttpClient<OpenProjectService>();

// 🔹 Register background service to fetch and save user stories
builder.Services.AddHostedService<HAIS.Backend.BackgroundServices.UserStoriesFetchService>();

var app = builder.Build();

// 🔹 Middleware pipeline
app.UseCors("AllowVueApp");
app.MapControllers();

app.Run();