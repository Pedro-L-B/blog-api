using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase
{
    public string CreateComment()
    {
        return "ok";
    }

    public string DeleteComment()
    {
        return "ok";
    }
}