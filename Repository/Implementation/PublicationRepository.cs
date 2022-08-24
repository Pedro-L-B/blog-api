using Blog.Api.Context;
using Blog.Api.Enums;
using Blog.Api.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using X.PagedList;

namespace Blog.Api.Repository.Implementation;

public class PublicationRepository : BaseRepository, IPublicationRepository
{
    private readonly BlogApiContext _context;
    public PublicationRepository(BlogApiContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Publication> GetById(int id)
    {
        var result = await _context.Publication?
            .Include(p => p.Comments)
            .FirstOrDefaultAsync(p => p.PublicationId == id)!;
        return result!;
    }

    public async Task<IPagedList<Publication>> List(
        int pageNumber,
        int pageSize,
        string? search,
        OrderByPublicationColumnEnum orderByCollumn,
        OrderByTypeEnum orderByType)
    {
        return await _context.Publication?
            .OrderBy($"{orderByCollumn.ToString()} {orderByType.ToString()}")
            .Where(p => p.Title!.Contains(search!))
            .ToPagedListAsync(pageNumber,pageSize)!;
    }

    public async Task<Publication> GetByTitle(string title)
    {
        var result = await _context.Publication?.FirstOrDefaultAsync(p => p.Title == title)!;
        return result!;
    }
}