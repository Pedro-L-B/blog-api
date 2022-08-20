using Blog.Api.Context;
using Blog.Api.Model;

namespace Blog.Api.Repository.Implementation;

public class CommentRepository : BaseRepository, ICommentRepository
{
    private readonly BlogApiContext _context;
    public CommentRepository(BlogApiContext context) : base(context)
    {
        _context = context;
    }

    public Comment GetById(int id)
    {
        return _context.Comment?.FirstOrDefault(p => p.CommentId == id)!;
    }
}