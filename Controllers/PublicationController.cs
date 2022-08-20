using Blog.Api.Context;
using Blog.Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PublicationController : ControllerBase
{
    private readonly BlogApiContext _context;

    public PublicationController(BlogApiContext context) {
        _context = context;
    }

    [HttpPost]
    public string CreatePublication([FromBody] Publication publication)
    {
        _context.Publication?.Add(publication);
        _context.SaveChanges();
        return "Publicação criada.";
    }

    [HttpPut("{id:int}")]
    public string EditPublication(int id, [FromBody] Publication publication)
    {
        _context.Publication?.Update(publication);
        _context.SaveChanges();
        return "Publicação atualizada.";
    }

    [HttpDelete("{id:int}")]
    public string DeletePublication(int id)
    {
        var publication = _context.Publication?.FirstOrDefault(p => p.PublicationId == id);
        _context.Publication?.Remove(publication!);
        return "Publicação removida.";
    }

    [HttpGet]
    public IEnumerable<Publication> ListPublication()
    {
        return _context.Publication!.ToList();
    }
}