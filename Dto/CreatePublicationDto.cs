namespace Blog.Api.Dto;

public class CreatePublicationDto
{
    public string? Title { get; set; }
    public string? Message { get; set; }
    public int CommentLimit { get; set; }
}