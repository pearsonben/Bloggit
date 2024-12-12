using Bloggit.Persistence;
using Bloggit.Services.Blogs;
using Microsoft.EntityFrameworkCore;

namespace Bloggit;

public static class ServiceRegistrations
{
    public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration);
        services.AddBlogServices();
    }

    private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BloggitDbContext>(options => options.UseSqlite(configuration.GetConnectionString(AppSettingsKeys.DatabaseName)));
    }

    private static void AddBlogServices(this IServiceCollection services)
    {
        services.AddScoped<IBlogService, BlogService>();
    }
}