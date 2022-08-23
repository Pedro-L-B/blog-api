using Blog.Api.Model;

namespace Blog.Api.Dto;

public class EditPublicationDto
{
    public int PublicationId { get; set; }
    public string? Title { get; set; }
    public string? Message { get; set; }
}