using System.ComponentModel.DataAnnotations;

namespace Blog.Api.Dto;

public class CreateCommentDto
{
    [Required(ErrorMessage = "É necessário inserir a mensagem.")]
    public string? Message { get; set; }

    [Required(ErrorMessage = "É necessário inserir o Id da publicação.")]
    public int PublicationId { get; set; }
}