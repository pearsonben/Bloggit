using Bloggit.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bloggit.Persistence;

public class BloggitDbContext : DbContext
{
    public BloggitDbContext(DbContextOptions<BloggitDbContext> options): base(options) { }

    public DbSet<Blog> Blogs { get; set; }
}