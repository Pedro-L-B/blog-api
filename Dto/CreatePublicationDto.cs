using System.ComponentModel.DataAnnotations;

namespace Blog.Api.Dto;

public class CreatePublicationDto
{
    [Required(ErrorMessage = "É necessário inserir o título da publicação.")]
    [MinLength(length: 5, ErrorMessage = "O título deve ter no mínimo 5 caracteres.")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "É necessário inserir a mensagem da publicação.")]
    [MaxLength(length: 500, ErrorMessage = "A mensagem deve ter no máximo 500 caracteres.")]
    public string? Message { get; set; }

    [Required(ErrorMessage = "É necessário inserir a quantidade máximda de comentários da publicação.")]
    [RegularExpression("([0-9]+)", ErrorMessage = "É necessário utilizar apenas números para definir o limite de comentários.")]
    public int CommentLimit { get; set; }

}