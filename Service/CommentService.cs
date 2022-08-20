using Blog.Api.Model;
using Blog.Api.Repository;

namespace Blog.Api.Services;

public class CommentService
{
    private readonly ICommentRepository _commentRepository;
    public CommentService(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public string CreateComment(Comment comment)
    {
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