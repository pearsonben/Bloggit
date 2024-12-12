namespace Bloggit.Services.Blogs.Requests;

public record CreateBlogRequest
{
    public string Slug { get; set; }
    public string Title { get; set; }
    public string RichTextContent { get; set; }
}