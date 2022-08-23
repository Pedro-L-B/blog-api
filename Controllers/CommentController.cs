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

    [HttpPost]
    public ActionResult<string> CreateComment([FromBody] CreateCommentDto comment)
    {
        try
        {
            return _commentService.CreateComment(comment);
        }
        catch (ErrorException errorException)
        {
            return StatusCode(errorException._statusCode, errorException.Message);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Tivemos um problema. Por favor, cantacte o suporte.");
        }
    }

    [HttpDelete("{id:int}")]
    public ActionResult<string> DeleteComment(int id)
    {
        try
        {
            return _commentService.DeleteComment(id);
        }
        catch (ErrorException errorException)
        {
            return StatusCode(errorException._statusCode, errorException.Message);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Tivemos um problema. Por favor, cantacte o suporte.");
        }
    }
}