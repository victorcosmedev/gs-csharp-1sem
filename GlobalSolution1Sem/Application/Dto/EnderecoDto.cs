using System.ComponentModel.DataAnnotations;

namespace GlobalSolution1Sem.Application.Dto
{
    public class EnderecoDto
    {
        [Required(ErrorMessage = "Id é obrigatório.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Logradouro é obrigatório.")]
        [StringLength(200, MinimumLength = 3)]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "Número é obrigatório.")]
        public string Numero { get; set; }
        [Required(ErrorMessage = "CEP é obrigatório.")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "")]
        public string Cep { get; set; }
        [Required(ErrorMessage = "Complemento é obrigatório.")]
        [StringLength(200, MinimumLength = 3)]
        public string Complemento { get; set; }
        [Required(ErrorMessage = "UsuarioId é obrigatório.")]
        public int UsuarioId { get; set; }
    }
}
