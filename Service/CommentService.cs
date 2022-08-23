using AutoMapper;
using Blog.Api.Dto;
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
        Comment comment = _mapper.Map<Comment>(createCommentDto);
        _commentRepository.Add(comment);
        return "Comentário criado.";
    }

    public string DeleteComment(int id)
    {
        var comment = _commentRepository.GetById(id);
        if (comment == null) return "Não existe comentário com esse Id.";
        _commentRepository.Delete(comment);
        return "Comentário removido.";
    }

}