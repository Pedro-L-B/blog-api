using System.ComponentModel.DataAnnotations;

namespace Blog.Api.Dto;

public class CreatePublicationDto
{
    [Required(ErrorMessage = "É necessário inserir o título da publicação.")]
    [MinLength(length: 5, ErrorMessage = "O título deve ter no mínimo 5 caracteres.")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "É necessário inserir a mensagem da publicação.")]
    public string? Message { get; set; }

    [Required(ErrorMessage = "É necessário inserir a quantidade máximda de comentários da publicação.")]
    public int CommentLimit { get; set; }

}