namespace Bloggit.Entities;

public class Blog : Entity
{
    public string Slug { get; set; }
    
    public string Title { get; set; }
    public string RichTextContent { get; set; }

    public static Blog Create(string slug, string title, string richTextContent)
    {
        return new Blog
        {
            Slug = slug,
            Title = title,
            RichTextContent = richTextContent
        };
    }
}