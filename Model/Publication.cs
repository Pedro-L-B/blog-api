namespace Blog.Api.Model;

public class Publication
{
    public Publication()
    {
        Comments = new List<Comment>();
        RegistrationDate = DateTime.Now;
    }

    public int PublicationId { get; set; }
    public string? Title { get; set; }
    public string? Message { get; set; }
    public DateTime RegistrationDate { get; set; }
    public List<Comment> Comments { get; set; }
    public int CommentLimit { get; set; }
}