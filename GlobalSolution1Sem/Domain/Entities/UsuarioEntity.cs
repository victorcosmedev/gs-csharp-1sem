using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution1Sem.Domain.Entities
{
    [Table("tb_cl_usuario")]
    public class UsuarioEntity
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public int? EnderecoId { get; set; }
        [InverseProperty("Usuario")]
        public virtual EnderecoEntity? Endereco { get; set; }
        public ICollection<PostEntity> Posts { get; set; }
    }
}
