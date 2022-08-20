using Blog.Api.Model;
using Blog.Api.Repository;
using Blog.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PublicationController : ControllerBase
{
    private readonly PublicationService _publicationService;

    public PublicationController(IPublicationRepository publicationRepository)
    {
        _publicationService = new PublicationService(publicationRepository);
    }

    [HttpPost]
    public string CreatePublication([FromBody] Publication publication)
    {
        return _publicationService.CreatePublication(publication);
    }

    [HttpPut("{id:int}")]
    public string EditPublication(int id, [FromBody] Publication publication)
    {
        if (id != publication.PublicationId) return "Id não confere";
        return _publicationService.EditPublication(id, publication);
    }

    [HttpDelete("{id:int}")]
    public string DeletePublication(int id)
    {
        return _publicationService.DeletePublication(id);
    }

    [HttpGet]
    public IEnumerable<Publication> ListPublication()
    {
        return _publicationService.ListPublication();
    }

    [HttpGet("{id:int}")]
    public Publication DetailPublication(int id)
    {
        return _publicationService.DetailPublication(id);
    }
}