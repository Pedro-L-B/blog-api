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
        var publication = _commentRepository.GetPublication(createCommentDto.PublicationId);
        if (publication == default)
            throw new ErrorException(StatusCodes.Status400BadRequest, "Não existe publicação com esse Id.");

        var messageCheck = _commentRepository.GetByMessage(createCommentDto.Message!);
        if (messageCheck != null)
            throw new ErrorException(StatusCodes.Status400BadRequest, "Já existe um outro comentário com a mesma mensagem.");

        var commentCountCheck = publication.Comments.Count();
        if (publication.CommentLimit <= commentCountCheck)
            throw new ErrorException(StatusCodes.Status400BadRequest, "Essa publicação já atingiu a quantidade máxima de comentários.");
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