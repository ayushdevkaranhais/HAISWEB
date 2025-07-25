using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class OpenProjectController : ControllerBase
{
    private readonly OpenProjectApi _openProjectApi;

    public OpenProjectController(OpenProjectApi openProjectApi)
    {
        _openProjectApi = openProjectApi;
    }

    [HttpGet("userstories")]
    public async Task<IActionResult> GetUserStories()
    {
        var stories = await _openProjectApi.GetUserStoriesAsync();
        return Ok(stories);
    }
}