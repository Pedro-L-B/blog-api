using Microsoft.AspNetCore.Mvc;
using Blog.Api.Model;
using Blog.Api.Services;
using Blog.Api.Repository;

namespace Blog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase
{
    private readonly CommentService _commentService;

    public CommentController(ICommentRepository commentRepository)
    {
        _commentService = new CommentService(commentRepository);
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