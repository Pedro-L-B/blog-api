using Blog.Api.Context;
using Blog.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Blog.Api.Repository.Implementation;

public class CommentRepository : BaseRepository, ICommentRepository
{
    private readonly BlogApiContext _context;
    public CommentRepository(BlogApiContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Comment> GetById(int id)
    {
        var result = await _context.Comment?.FirstOrDefaultAsync(c => c.CommentId == id)!;
        return result!;
    }

    public async Task<IEnumerable<Comment>> List()
    {
        return await _context.Comment?.ToListAsync()!;
    }

    // public async Task<Comment> GetByMessage(string message)
    // {
    //     var result = await _context.Comment?
    //         .ToListAsync()
    //         .FirstOrDefaultAsync(c => c.Message == message)!;
    //     return result!;
    // }

    public async Task<List<Publication>> GetPublication ()
    {
        return await _context.Publication?
            .Include(p => p.Comments)
            .ToListAsync()!;
    }
}