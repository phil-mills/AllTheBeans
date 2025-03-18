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

    [HttpPost(Name = "PostBean")]
    public async Task<IActionResult> PostBean(Bean bean)
    {
        var createdBeanId = await this.beansDomain.CreateBeanAsync(bean.ToDomainBean());

        if (createdBeanId != null)
        {
             return CreatedAtRoute("Created Bean Id: ", new { id = createdBeanId });
        }
    
        return BadRequest();
    }

    [HttpPatch(Name = "PatchBean")]
    public async Task<IActionResult> PatchBean(Bean bean)
    {
        var updatedBeanId = await this.beansDomain.UpdateBeanAsync(bean.ToDomainBean());

        if (updatedBeanId != null)
        {
             return Ok();
        }
    
        return BadRequest();
    }

    [HttpDelete(Name = "DeleteBean")]
    public async Task<IActionResult> DeleteBean(string id)
    {
        var result = await this.beansDomain.DeleteBeanAsync(id);

        if (result)
        {
            return Ok();
        }

        return NotFound();
    }

    [HttpGet(Name = "GetById")]
    public async Task<IActionResult> GetBean(string id)
    {
        var bean = await this.beansDomain.GetBeanAsync(id);

        if (bean != null)
        {
            return Ok(bean);
        }

        return NotFound();
    }

    [HttpGet(Name = "GetBeanOfTheDay")]
    public async Task<IActionResult> GetBeanOfTheDay()
    {
        var beanOfTheDay = await this.beansDomain.GetBeanOfTheDayAsync();

       return Ok(beanOfTheDay);
    }
}
