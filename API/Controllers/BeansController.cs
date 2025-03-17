using System.Threading.Tasks;
using Domain.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class BeansController : ControllerBase
{
    private readonly ILogger<BeansController> logger;
    private readonly IGetBeanOfTheDay getBeanOfTheDay;

    public BeansController(ILogger<BeansController> logger, IGetBeanOfTheDay getBeanOfTheDay)
    {
        this.logger = logger;
        this.getBeanOfTheDay = getBeanOfTheDay;
    }

    [HttpGet(Name = "GetBeanOfTheDay")]
    public async Task<IActionResult> Get()
    {
        var beanOfTheDay = await getBeanOfTheDay.GetBeanOfTheDayAsync();

       return Ok(beanOfTheDay);
    }
}
