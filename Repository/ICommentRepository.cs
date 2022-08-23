using Blog.Api.Model;

namespace Blog.Api.Repository;

public interface ICommentRepository : IBaseRepository
{
    Comment GetById(int id);
    IEnumerable<Comment> List();
    Comment GetByMessage(string message);
    Publication GetPublication (int publicationId);
}