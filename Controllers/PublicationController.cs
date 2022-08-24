using AutoMapper;
using Blog.Api.Dto;
using Blog.Api.Exceptions;
using Blog.Api.Repository;
using Blog.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Blog.Api.Enums;
using Microsoft.EntityFrameworkCore;

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
    public async Task<ActionResult> CreatePublication([FromBody] CreatePublicationDto createPublicationDto)
    {
        try
        {
            await _publicationService.CreatePublication(createPublicationDto);
            return new NoContentResult();
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
    ///         "message": "Escrevendo um novo texto.",
    ///         "commentLimit": 4
    ///     }
    /// 
    /// </remarks>
    /// <response code="204"> Publicação alterada com sucesso. </response>
    /// <response code="400"> A publicação não foi alterada. </response>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpPut("{id:int}")]
    public async Task<ActionResult> EditPublication(int id, [FromBody] EditPublicationDto editPublicationDto)
    {
        try
        {
            await _publicationService.EditPublication(id, editPublicationDto);
            return new NoContentResult();
        }
        catch (ErrorException errorException)
        {
            return StatusCode(errorException._statusCode, errorException.Message);
        }
        catch (DbUpdateConcurrencyException)
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Não existe publicação com esse Id.");
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
    public async Task<ActionResult> DeletePublication(int id)
    {
        try
        {
            await _publicationService.DeletePublication(id);
            return new NoContentResult();
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
    /// <param name="pageNumber"> Número da página solicitada. </param>
    /// <param name="pageSize"> Quantidade de publicações por página. </param>
    /// <param name="search"> Mecanismo de busca por texto. </param>
    /// <param name="orderByCollumn"> Ordenação de publicações por coluna. </param>
    /// <param name="orderByType"> Ordenação de publicações por tipo. </param>
    /// <response code="200"> Lista de publicações encontrada. </response>
    /// <response code="400"> Nenhuma lista de publicações encontrada. </response>
    [HttpGet]
    public async Task<ActionResult<dynamic>> ListPublication(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 3,
        [FromQuery] string? search = "",
        [FromQuery] OrderByPublicationColumnEnum orderByCollumn = OrderByPublicationColumnEnum.PublicationId,
        [FromQuery] OrderByTypeEnum orderByType = OrderByTypeEnum.ASC
    )
    {
        try
        {
            return await _publicationService.ListPublication(pageNumber, pageSize, search, orderByCollumn, orderByType);
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
    public async Task<ActionResult<DetailPublicationDto>> DetailPublication(int id)
    {
        try
        {
            var result = await _publicationService.DetailPublication(id);
            return new OkObjectResult(result);
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