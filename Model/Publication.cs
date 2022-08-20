namespace Blog.Api.Model;

public class Publication
{
    public int PublicationId { get; set; }
    public string? Title { get; set; }
    public string? Message { get; set; }
    public DateTime RegistrationDate { get; set; }
}