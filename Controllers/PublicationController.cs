using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PublicationController : ControllerBase
{
    public string CreatePublication()
    {
        return "ok";
    }

    public string EditPublication()
    {
        return "ok";
    }

    public string DeletePublication()
    {
        return "ok";
    }

    public string ListPublication()
    {
        return "ok";
    }
}