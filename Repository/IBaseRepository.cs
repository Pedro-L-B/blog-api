namespace Blog.Api.Repository;
public interface IBaseRepository
{
    void Add<TEntity>(TEntity Entity) where TEntity : class;
    void Update<TEntity>(TEntity Entity) where TEntity : class;
    void Delete<TEntity>(TEntity Entity) where TEntity : class;
    bool SaveChanges();
}