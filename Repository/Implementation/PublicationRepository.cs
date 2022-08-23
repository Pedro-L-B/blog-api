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

    public Publication GetById(int id)
    {
        return _context.Publication?
            .Include(p => p.Comments)
            .FirstOrDefault(p => p.PublicationId == id)!;
    }

    public IEnumerable<Publication> List(
        int pageNumber,
        int pageSize,
        string? search,
        OrderByPublicationColumnEnum orderByCollumn,
        OrderByTypeEnum orderByType)
    {
        return _context.Publication?
            .OrderBy($"{orderByCollumn.ToString()} {orderByType.ToString()}")
            .Where(p => p.Title!.Contains(search!))
            .ToPagedList(pageNumber,pageSize)!;
    }

    public Publication GetByTitle(string title)
    {
        return _context.Publication?.FirstOrDefault(p => p.Title == title)!;
    }
}