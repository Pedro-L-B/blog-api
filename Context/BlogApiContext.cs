using Blog.Api.EntityConfig;
using Blog.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Blog.Api.Context;
public class BlogApiContext : DbContext
{
    public BlogApiContext(DbContextOptions<BlogApiContext> options) : base (options) {}

    public DbSet<Comment>? Comment { get; set;}
    public DbSet<Publication>? Publication { get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Comment>(new CommentConfig().Configure);
        modelBuilder.Entity<Publication>(new PublicationConfig().Configure);
    }
}