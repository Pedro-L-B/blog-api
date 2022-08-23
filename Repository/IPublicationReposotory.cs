using Blog.Api.Enums;
using Blog.Api.Model;
using X.PagedList;

namespace Blog.Api.Repository;

public interface IPublicationRepository : IBaseRepository
{
    Publication GetById(int id);
    IPagedList<Publication> List(
        int pageNumber,
        int pageSize,
        string search,
        OrderByPublicationColumnEnum orderByCollumn,
        OrderByTypeEnum orderByType);
    Publication GetByTitle(string title);
}