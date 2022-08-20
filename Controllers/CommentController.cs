using Microsoft.AspNetCore.Mvc;
using Blog.Api.Context;
using Blog.Api.Model;
using Blog.Api.Services;

namespace Blog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase
{
    private readonly CommentService _commentService;

    public CommentController(BlogApiContext context)
    {
        _commentService = new CommentService(context);
    }

    [HttpPost]
    public string CreateComment([FromBody] Comment comment)
    {
        return _commentService.CreateComment(comment);
    }

    [HttpDelete("{id:int}")]
    public string DeleteComment(int id)
    {
        return _commentService.DeleteComment(id);
    }
}