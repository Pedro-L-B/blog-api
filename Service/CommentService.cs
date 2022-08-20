using Blog.Api.Context;
using Blog.Api.Model;

namespace Blog.Api.Services;

public class CommentService
{
    private readonly BlogApiContext _context;
    public CommentService(BlogApiContext context)
    {
        _context = context;
    }

    public string CreateComment(Comment comment)
    {
        _context.Comment?.Add(comment);
        _context.SaveChanges();
        return "Comentário criado.";
    }

    public string DeleteComment(int id)
    {
        var comment = _context.Comment?.FirstOrDefault(c => c.CommentId == id);
        _context.Comment?.Remove(comment!);
        _context.SaveChanges();
        return "Comentário removido.";
    }

}