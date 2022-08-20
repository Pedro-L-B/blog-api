using Blog.Api.Context;

namespace Blog.Api.Repository.Implementation;

public class BaseRepository : IBaseRepository
{
    private readonly BlogApiContext _context;
    public BaseRepository(BlogApiContext context)
    {
        _context = context;
    }
    public void Add<TEntity>(TEntity entity) where TEntity : class
    {
        _context.Add<TEntity>(entity);
        SaveChanges();
    }

    public void Delete<TEntity>(TEntity entity) where TEntity : class
    {
        _context.Remove<TEntity>(entity);
        SaveChanges();
    }

    public void Update<TEntity>(TEntity entity) where TEntity : class
    {
        _context.Update<TEntity>(entity);
        SaveChanges();
    }

    public bool SaveChanges()
    {
        return _context.SaveChanges() > 0;
    }
}