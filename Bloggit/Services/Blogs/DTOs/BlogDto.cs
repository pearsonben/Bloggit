
using Bloggit.Entities;

namespace Bloggit.Services.Blogs.DTOs;

public record BlogDto
{
    public string Slug { get; set; }
    public string Title { get; set; }
    public string RichTextContent { get; set; }

    public static BlogDto FromBlog(Blog blog) => new BlogDto
    {
        Title = blog.Title,
        Slug = blog.Slug,
        RichTextContent = blog.RichTextContent
    };
}