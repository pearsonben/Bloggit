using Bloggit.Entities;
using Bloggit.Persistence;
using Bloggit.Services.Blogs.DTOs;
using Bloggit.Services.Blogs.Requests;
using Bloggit.Services.Blogs.Responses;
using Microsoft.EntityFrameworkCore;

namespace Bloggit.Services.Blogs;

public class BlogService : IBlogService
{
    private readonly BloggitDbContext _dbContext;

    public BlogService(BloggitDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Result<List<BlogDto>>> GetBlogsAsync()
    {
        var blogs = await _dbContext.Blogs.ToListAsync();

        var blogDtos = blogs.Select(BlogDto.FromBlog).ToList();
        
        return Result<List<BlogDto>>.Success(blogDtos);
    }

    public async Task<Result<BlogDto>> CreateBlogAsync(CreateBlogRequest request)
    {
        
        var isDuplicateSlug = await _dbContext.Blogs.AnyAsync(x => x.Slug == request.Slug);

        if (isDuplicateSlug) return Result<BlogDto>.Failure("This Blog already exists.");

        var blogToCreate = Blog.Create(request.Slug, request.Title, request.RichTextContent);
        
        _dbContext.Blogs.Add(blogToCreate);
        
        var result = await _dbContext.SaveChangesAsync();

        return result switch
        {
            1 => Result<BlogDto>.Success(BlogDto.FromBlog(blogToCreate)),
            _ => Result<BlogDto>.Failure("There was an error creating the blog")
        };
    }
}