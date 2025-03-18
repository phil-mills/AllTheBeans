using System.Threading.Tasks;
using API.Controllers.Entities;
using Domain.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class BeansController : ControllerBase
{
    private readonly ILogger<BeansController> logger;

    private readonly IBeansDomain beansDomain;

    public BeansController(ILogger<BeansController> logger, IBeansDomain beansDomain)
    {
        this.logger = logger;
        this.beansDomain = beansDomain;
    }

    [HttpPost]
    public async Task<IActionResult> PostBean(Bean bean)
    {
        var createdBeanId = await this.beansDomain.CreateBeanAsync(bean.ToDomainBean());

        if (createdBeanId != null)
        {
             return Created("Id: ", new { id = createdBeanId });
        }
    
        return BadRequest();
    }

    [HttpPatch]
    public async Task<IActionResult> PatchBean(Bean bean)
    {
        var updatedBeanId = await this.beansDomain.UpdateBeanAsync(bean.ToDomainBean());

        if (updatedBeanId != null)
        {
             return Ok();
        }
    
        return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBean(string id)
    {
        var result = await this.beansDomain.DeleteBeanAsync(id);

        if (result)
        {
            return Ok();
        }

        return NotFound();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBean(string id)
    {
        var bean = await this.beansDomain.GetBeanAsync(id);

        if (bean != null)
        {
            return Ok(bean);
        }

        return NotFound();
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetBeans()
    {
        var beans = await this.beansDomain.GetAllBeanAsync();

        return Ok(beans);
    }

    [HttpGet("botd")]
    public async Task<IActionResult> GetBeanOfTheDay()
    {
        var beanOfTheDay = await this.beansDomain.GetBeanOfTheDayAsync();

        if (beanOfTheDay != null)
        {
            return Ok(beanOfTheDay);
        }

       return NotFound();
    }
}
