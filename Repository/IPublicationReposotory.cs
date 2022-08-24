using Blog.Api.Enums;
using Blog.Api.Model;
using X.PagedList;

namespace Blog.Api.Repository;

public interface IPublicationRepository : IBaseRepository
{
    Task<Publication> GetById(int id);
    Task<IPagedList<Publication>> List(
        int pageNumber,
        int pageSize,
        string search,
        OrderByPublicationColumnEnum orderByCollumn,
        OrderByTypeEnum orderByType);
    Task<Publication> GetByTitle(string title);
}