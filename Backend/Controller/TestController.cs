using Microsoft.AspNetCore.Mvc;

namespace HAISWEB.Backend.Controllers // <-- Update this to match your project name
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from .NET backend!");
        }
    }
}