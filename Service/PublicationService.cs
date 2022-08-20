using Blog.Api.Context;
using Blog.Api.Model;

namespace Blog.Api.Services;

public class PublicationService
{
    private readonly BlogApiContext _context;
    public PublicationService(BlogApiContext context)
    {
        _context = context;
    }

    public string CreatePublication(Publication publication)
    {
        _context.Publication?.Add(publication);
        _context.SaveChanges();
        return "Publicação criada.";
    }

    public string EditPublication(int id, Publication publication)
    {
        _context.Publication?.Update(publication);
        _context.SaveChanges();
        return "Publicação atualizada.";
    }

    public string DeletePublication(int id)
    {
        var publication = _context.Publication?.FirstOrDefault(p => p.PublicationId == id);
        _context.Publication?.Remove(publication!);
        _context.SaveChanges();
        return "Publicação removida.";
    }

    public IEnumerable<Publication> ListPublication()
    {
        return _context.Publication!.ToList();
    }
}