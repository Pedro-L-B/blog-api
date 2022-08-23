using AutoMapper;
using Blog.Api.Dto;
using Blog.Api.Exceptions;
using Blog.Api.Repository;
using Blog.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Blog.Api.Enums;

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
    public ActionResult<string> CreatePublication([FromBody] CreatePublicationDto createPublicationDto)
    {
        try
        {
            return _publicationService.CreatePublication(createPublicationDto);
        }
        catch (ErrorException errorException)
        {
            return StatusCode(errorException._statusCode, errorException.Message);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Tivemos um problema. Por favor, cantate o suporte.");
        }
    }

    [HttpPut]
    public ActionResult<string> EditPublication(int id, [FromBody] EditPublicationDto editPublicationDto)
    {
        try
        {
            if (id != editPublicationDto.PublicationId) return "Id não confere";
            return _publicationService.EditPublication(id, editPublicationDto);
        }
        catch (ErrorException errorException)
        {
            return StatusCode(errorException._statusCode, errorException.Message);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Tivemos um problema. Por favor, cantate o suporte.");
        }
    }

    [HttpDelete("{id:int}")]
    public ActionResult<string> DeletePublication(int id)
    {
        try
        {
            return _publicationService.DeletePublication(id);
        }
        catch (ErrorException errorException)
        {
            return StatusCode(errorException._statusCode, errorException.Message);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Tivemos um problema. Por favor, cantate o suporte.");
        }
    }

    [HttpGet]
    public IEnumerable<ListPublicationDto> ListPublication(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 5,
        [FromQuery] string? search = "",
        [FromQuery] OrderByPublicationColumnEnum orderByCollumn = OrderByPublicationColumnEnum.PublicationId,
        [FromQuery] OrderByTypeEnum orderByType = OrderByTypeEnum.ASC
    )
    {
        return _publicationService.ListPublication(pageNumber, pageSize, search, orderByCollumn, orderByType);
    }

    [HttpGet("{id:int}")]
    public ActionResult<DetailPublicationDto> DetailPublication(int id)
    {
        try
        {
            return _publicationService.DetailPublication(id);
        }
        catch (ErrorException errorException)
        {
            return StatusCode(errorException._statusCode, errorException.Message);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Tivemos um problema. Por favor, cantate o suporte.");
        }
    }
}