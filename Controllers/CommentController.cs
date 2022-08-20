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

    [HttpDelete("{id:int}")]
    public string DeleteComment(int id)
    {
        return "ok";
    }
}