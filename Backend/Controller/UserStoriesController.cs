using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HAIS.Backend.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserStoriesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUserStories()
        {
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "user_stories");
            if (!Directory.Exists(folderPath))
                return Ok(new string[0]);

            var files = Directory.GetFiles(folderPath, "story-*.md");
            var stories = files.Select(f => new {
                FileName = Path.GetFileName(f),
                Content = System.IO.File.ReadAllText(f)
            }).ToList();
            return Ok(stories);
        }
    }
}
