namespace Bloggit.Entities;

public class Blog : Entity
{
    public string Slug { get; private set; }
    public string Title { get; private set; }
    public string RichTextContent { get; private set; }

    public static Blog Create(string title, string richTextContent)
    {
        return new Blog
        {
            Slug = string.Join("-", title.ToLower().Split(' ')),
            Title = title,
            RichTextContent = richTextContent
        };
    }
}