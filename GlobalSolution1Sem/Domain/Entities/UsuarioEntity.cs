using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution1Sem.Domain.Entities
{
    public class UsuarioEntity
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        [ForeignKey(nameof(Endereco))]
        public int EnderecoId { get; set; }
        public virtual EnderecoEntity Endereco { get; set; }
        public ICollection<PostEntity> Posts { get; set; }
    }
}
