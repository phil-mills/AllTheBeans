using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class BeansController : ControllerBase
{
    private readonly ILogger<BeansController> _logger;

    public BeansController(ILogger<BeansController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "Get")]
    public IActionResult Get()
    {
       return Ok("Hello World");
    }
}
