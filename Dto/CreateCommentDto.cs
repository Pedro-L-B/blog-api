namespace Blog.Api.Dto;

public class CreateCommentDto
{
    public string? Message { get; set; }
    public int PublicationId { get; set; }
}