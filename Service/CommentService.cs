using AutoMapper;
using Blog.Api.Dto;
using Blog.Api.Exceptions;
using Blog.Api.Model;
using Blog.Api.Repository;

namespace Blog.Api.Services;

public class CommentService
{
    private readonly IMapper _mapper;
    private readonly ICommentRepository _commentRepository;
    public CommentService(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public string CreateComment(CreateCommentDto createCommentDto)
    {
        var result = _commentRepository.List().FirstOrDefault(c => c.Message == createCommentDto.Message);
        if (result != null) throw new ErrorException(StatusCodes.Status400BadRequest, "Já existe um comentário com a mesma mensagem.");
        var comment = _mapper.Map<Comment>(createCommentDto);
        _commentRepository.Add(comment);
        return "Comentário criado.";
    }

    public string DeleteComment(int id)
    {
        var comment = _commentRepository.GetById(id);
        if (comment == null) throw new ErrorException (StatusCodes.Status400BadRequest, "Não existe comentário com esse Id.");
        _commentRepository.Delete(comment);
        return "Comentário removido.";
    }

}