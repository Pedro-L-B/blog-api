using AutoMapper;
using Blog.Api.Dto;
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

    public PublicationController(IPublicationRepository publicationRepository, IMapper mapper)
    {
        _publicationService = new PublicationService(publicationRepository, mapper);
    }

    [HttpPost]
    public string CreatePublication([FromBody] CreatePublicationDto createPublicationDto)
    {
        return _publicationService.CreatePublication(createPublicationDto);
    }

    [HttpPut]
    public string EditPublication(int id, [FromBody] EditPublicationDto editPublicationDto)
    {
        if (id != editPublicationDto.PublicationId) return "Id não confere";
        return _publicationService.EditPublication(id, editPublicationDto);
    }

    [HttpDelete("{id:int}")]
    public string DeletePublication(int id)
    {
        return _publicationService.DeletePublication(id);
    }

    [HttpGet]
    public IEnumerable<ListPublicationDto> ListPublication()
    {
        return _publicationService.ListPublication();
    }

    [HttpGet("{id:int}")]
    public DetailPublicationDto DetailPublication(int id)
    {
        return _publicationService.DetailPublication(id);
    }
}