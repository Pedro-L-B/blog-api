using Blog.Api.Model;

namespace Blog.Api.Repository;

public interface IPublicationRepository : IBaseRepository
{
    Publication GetById(int id);
    IEnumerable<Publication> List();
    Publication GetByTitle(string title);
}