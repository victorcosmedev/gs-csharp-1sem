using System.ComponentModel.DataAnnotations;

namespace GlobalSolution1Sem.Application.Dto
{
    public class UsuarioDto
    {
        [Required(ErrorMessage = "Id é obrigatório.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Nome deve ter entre 3 e 100 caracteres.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "CPF é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF deve ter 11 caracteres.")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Data de nascimento é obrigatória.")]
        [Range(typeof(DateTime), "1900-01-01", "2025-05-30", ErrorMessage = "Data de nascimento inválida.")]
        public DateTime DataNascimento { get; set; }
        public int? EnderecoId { get; set; }
    }
}
