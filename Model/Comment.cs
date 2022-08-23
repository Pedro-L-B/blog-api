namespace Blog.Api.Model;

public class Comment
{
    public Comment() {
        RegistrationDate = DateTime.Now;
    }
    public int CommentId { get; set; }
    public string? Message { get; set; }
    public DateTime RegistrationDate { get; set; }
    public int PublicationId { get; set; }
    public Publication? Publication { get; set; }
}