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
    /// <summary> Endpoint para criar uma publicação. </summary>
    /// <remarks>
    /// Exemplo RequestBody:
    /// 
    ///     {
    ///         "title": "Escrevendo um título",
    ///         "message": "Escrevendo um texto completo.",
    ///         "commentLimit": 3
    ///     }
    /// 
    /// </remarks>
    /// <response code="201"> Publicação registrada com sucesso. </response>
    /// <response code="400"> A publicação não foi criada. </response>
    [ProducesResponseType(StatusCodes.Status201Created)]
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

    /// <summary> Endpoint para editar uma publicação. </summary>
    /// <remarks>
    /// Exemplo RequestBody:
    /// 
    ///     {
    ///         "publicationId": 12,
    ///         "title": "Escrevendo o novo título",
    ///         "message": "Escrevendo um novo texto."
    ///     }
    /// 
    /// </remarks>
    /// <response code="204"> Publicação alterada com sucesso. </response>
    /// <response code="400"> A publicação não foi alterada. </response>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
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

    /// <summary> Endpoint deletar uma publicação. </summary>
    /// <remarks>
    /// Exemplo RequestBody:
    /// 
    ///     12
    /// 
    /// </remarks>
    /// <param name="id"> Id da publicação que deve ser apagada. </param>
    /// <response code="204"> Publicação apagada com sucesso. </response>
    /// <response code="400"> A publicação não foi apagada. </response>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
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

    /// <summary> Endpoint para retornar uma lista paginada de publicações. </summary>
    /// <remarks>
    /// Exemplo RequestBody:
    /// 
    ///     {
    ///         pageNumber = 1,
    ///         pageSize = 3,
    ///         search = "Palavra"
    ///         orderByCollumn = PublicationId,
    ///         orderByType = ASC
    ///     }
    /// 
    /// </remarks>
    /// <param name="pageNumber"> Página atual. </param>
    /// <param name="pageSize"> Quantidade de publicações por página. </param>
    /// <param name="search"> Mecanismos de busca por texto. </param>
    /// <param name="orderByCollumn"> Ordenação de publicações por coluna. </param>
    /// <param name="orderByType"> Ordenação de publicações por tipo. </param>
    /// <response code="200"> Lista de publicações encontrada. </response>
    /// <response code="400"> Nenhuma lista de publicações encontrada. </response>
    [HttpGet]
    public dynamic ListPublication(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 3,
        [FromQuery] string? search = "",
        [FromQuery] OrderByPublicationColumnEnum orderByCollumn = OrderByPublicationColumnEnum.PublicationId,
        [FromQuery] OrderByTypeEnum orderByType = OrderByTypeEnum.ASC
    )
    {
        try
        {
            return _publicationService.ListPublication(pageNumber, pageSize, search, orderByCollumn, orderByType);
        }
        catch (ArgumentOutOfRangeException)
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Os campos de paginamento devem conter apenas números inteiros e positivos.");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Tivemos um problema. Por favor, cantate o suporte.");
        }
    }

    /// <summary> Endpoint para retornar uma única publicação. </summary>
    /// <remarks>
    /// Exemplo RequestBody:
    /// 
    ///     13
    /// 
    /// </remarks>
    /// <param name="id"> Id da publicaçãoq ue deseja ser encontrada. </param>
    /// <response code="200"> Publicação encontrada. </response>
    /// <response code="400"> Nenhuma publicação encontrada. </response>
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