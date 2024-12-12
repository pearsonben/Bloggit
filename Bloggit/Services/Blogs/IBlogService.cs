using Bloggit.Services.Blogs.DTOs;
using Bloggit.Services.Blogs.Requests;
using Bloggit.Services.Blogs.Responses;

namespace Bloggit.Services.Blogs;

public interface IBlogService
{
    Task<Result<List<BlogDto>>> GetBlogsAsync();
    
    Task<Result<BlogDto>> CreateBlogAsync(CreateBlogRequest request);
}
