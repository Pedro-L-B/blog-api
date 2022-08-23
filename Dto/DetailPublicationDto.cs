using Blog.Api.Model;

namespace Blog.Api.Dto;

public class DetailPublicationDto
{
    public DetailPublicationDto()
    {
        Comments = new List<DetailCommentDto>();
    }

    public int PublicationId { get; set; }
    public string? Title { get; set; }
    public string? Message { get; set; }
    public DateTime RegistrationDate { get; set; }
    public List<DetailCommentDto> Comments { get; set; }
    public int CommentLimit { get; set; }
}