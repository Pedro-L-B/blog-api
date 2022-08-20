using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase
{
    [HttpPost]
    public string CreateComment()
    {
        return "ok";
    }

    [HttpDelete]
    public string DeleteComment()
    {
        return "ok";
    }
}