using Blog.Api.Model;

namespace Blog.Api.Repository;

public interface ICommentRepository : IBaseRepository
{
    Task<Comment> GetById(int id);
    Task<IEnumerable<Comment>> List();
    // Task<Comment> GetByMessage(string message);
    Task<List<Publication>> GetPublication ();
}