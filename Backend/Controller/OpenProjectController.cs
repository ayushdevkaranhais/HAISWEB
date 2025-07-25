using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.IO;
using HAIS.Backend.Services;



namespace HAIS.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OpenProjectController : ControllerBase
    {
        private readonly OpenProjectService _openProjectService;

        public OpenProjectController(OpenProjectService openProjectService)
        {
            _openProjectService = openProjectService;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            // TODO: Replace with real authentication logic
            // For now, accept two hardcoded users for demo
            if ((request.Email == "admin@example.com" && request.Password == "Admin@123") ||
                (request.Email == "user@example.com" && request.Password == "User@1234"))
            {
                var role = request.Email.StartsWith("admin") ? "admin" : "user";
                // Simulate JWT
                var token = "fake-jwt-token";
                return Ok(new { token, user = new { email = request.Email, role } });
            }
            return Unauthorized("Invalid credentials");
        }

        public class LoginRequest
        {
            public string Email { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
        }

        [HttpGet("user-stories")]
        public async Task<IActionResult> GetUserStories()
        {
            var isAuthenticated = await _openProjectService.AuthenticateAsync();
            if (!isAuthenticated)
            {
                return Unauthorized("Authentication failed.");
            }

            var stories = await _openProjectService.FetchUserStoriesAsync();
            // 💾 Save stories to disk in /user_stories folder
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "user_stories");
            Directory.CreateDirectory(folderPath);

            int count = 0;
            foreach (var story in stories)
            {
                string fileName = $"story-{count + 1}.md";
                string path = Path.Combine(folderPath, fileName);
                await System.IO.File.WriteAllTextAsync(path, story);
                count++;
            }

            return Ok($"✅ {count} user stories saved.");
        }
    }
}
