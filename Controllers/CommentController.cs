using Microsoft.AspNetCore.Mvc;
using Blog.Api.Context;
using Blog.Api.Model;

namespace Blog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase
{
    private readonly BlogApiContext _context;

    public CommentController(BlogApiContext context) {
        _context = context;
    }

    [HttpPost]
    public string CreateComment([FromBody] Comment comment)
    {
        _context.Comment?.Add(comment);
        _context.SaveChanges();
        return "Comentário criado.";
    }

    [HttpDelete("{id:int}")]
    public string DeleteComment(int id)
    {
        var comment = _context.Comment?.FirstOrDefault(c => c.CommentId == id);
        _context.Comment?.Remove(comment!);
        _context.SaveChanges();
        return "Comentário removido.";
    }
}