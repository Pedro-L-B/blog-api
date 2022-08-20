using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PublicationController : ControllerBase
{
    [HttpPost]
    public string CreatePublication()
    {
        return "ok";
    }

    [HttpPut("{id:int}")]
    public string EditPublication(int id)
    {
        return "ok";
    }

    [HttpDelete("{id:int}")]
    public string DeletePublication(int id)
    {
        return "ok";
    }

    [HttpGet]
    public string ListPublication()
    {
        return "ok";
    }
}