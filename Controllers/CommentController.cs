using Microsoft.AspNetCore.Mvc;
using Blog.Api.Services;
using Blog.Api.Repository;
using Blog.Api.Dto;
using AutoMapper;
using Blog.Api.Exceptions;

namespace Blog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase
{
    private readonly CommentService _commentService;

    public CommentController(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentService = new CommentService(commentRepository, mapper);
    }

    /// <summary> Endpoint para criar um comentário. </summary>
    /// <remarks>
    /// Exemplo RequestBody:
    /// 
    ///     {
    ///         "message": "Texto do comentário",
    ///         "publicationId": 13
    ///     }
    /// 
    /// </remarks>
    /// <response code="201"> Comentário criado com sucesso. </response>
    /// <response code="400"> O comentário não foi criado. </response>
    [ProducesResponseType(StatusCodes.Status201Created)]
    [HttpPost]
    public async Task<ActionResult> CreateComment([FromBody] CreateCommentDto comment)
    {
        try
        {
            await _commentService.CreateComment(comment);
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

    /// <summary> Endpoint deletar um comentário. </summary>
    /// <remarks>
    /// Exemplo RequestBody:
    /// 
    ///     12
    /// 
    /// </remarks>
    /// <param name="id"> Id do comentário que deve ser apagado. </param>
    /// <response code="204"> Comentário apagado com sucesso. </response>
    /// <response code="400"> O comentário não foi apagado. </response>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteComment(int id)
    {
        try
        {
            await _commentService.DeleteComment(id);
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
}