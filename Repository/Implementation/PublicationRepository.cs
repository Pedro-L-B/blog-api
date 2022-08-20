namespace Blog.Api.Repository.Implementation;

using System.Collections.Generic;
using Blog.Api.Context;
using Blog.Api.Model;

public class PublicationRepository : BaseRepository, IPublicationRepository
{
    private readonly BlogApiContext _context;
    public PublicationRepository(BlogApiContext context) : base(context)
    {
        _context = context;
    }

    public Publication GetById(int id)
    {
        return _context.Publication?.FirstOrDefault(p => p.PublicationId == id)!;
    }

    public IEnumerable<Publication> List()
    {
        return _context.Publication?.ToList()!;
    }
}