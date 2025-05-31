using System.ComponentModel.DataAnnotations;

namespace GlobalSolution1Sem.Application.Dto
{
    public class PostDto
    {
        [Required(ErrorMessage = "Id é obrigatório.")]

        public int Id { get; set; }
        [Required(ErrorMessage = "Título é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Título tem que ter entre 3 e 100 caracteres")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Descrição é obrigatória")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Descrição tem que ter entre 3 e 250 caracteres")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Data de criação é obrigatória.")]
        public DateTime DataCriacao { get; set; }
        [Required(ErrorMessage = "Id do usuário é obrigatório")]
        public int UsuarioId { get; set; }
    }
}
