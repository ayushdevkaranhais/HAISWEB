var builder = WebApplication.CreateBuilder(args);

// Allow frontend from Vite/Vue (port 8080)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp", policy =>
    {
        policy.WithOrigins("http://localhost:8080")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add controllers
builder.Services.AddControllers();

// Register OpenProjectApi service with HttpClient for DI
builder.Services.AddHttpClient<OpenProjectApi, OpenProjectApi>();


var app = builder.Build();

// Fetch and save user stories from OpenProject on backend startup
using (var scope = app.Services.CreateScope())
{
    var openProjectApi = scope.ServiceProvider.GetRequiredService<OpenProjectApi>();
    try
    {
        var userStories = await openProjectApi.GetUserStoriesAsync();
        var json = System.Text.Json.JsonSerializer.Serialize(userStories, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
        var filePath = System.IO.Path.Combine(AppContext.BaseDirectory, "userstories.json");
        await System.IO.File.WriteAllTextAsync(filePath, json);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Failed to fetch or save user stories: {ex.Message}");
    }
}

// Enable CORS
app.UseCors("AllowVueApp");

// Map controller routes (e.g. /api/openproject/userstories)
app.MapControllers();

app.Run();