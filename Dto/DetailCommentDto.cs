namespace Blog.Api.Dto;

public class DetailCommentDto
{
    public int CommentId { get; set; }
    public string? Message { get; set; }
    public DateTime RegistrationDate { get; set; }
}