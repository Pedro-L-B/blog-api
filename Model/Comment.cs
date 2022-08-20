namespace Blog.Api.Model;

public class Comment
{
    public int CommentId { get; set; }
    public string? Message { get; set; }
    public DateTime RegistrationDate { get; set; }
}