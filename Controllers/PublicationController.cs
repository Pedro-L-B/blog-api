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

    [HttpPut]
    public string EditPublication()
    {
        return "ok";
    }

    [HttpDelete]
    public string DeletePublication()
    {
        return "ok";
    }

    [HttpGet]
    public string ListPublication()
    {
        return "ok";
    }
}