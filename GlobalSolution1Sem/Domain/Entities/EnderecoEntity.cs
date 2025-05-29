using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution1Sem.Domain.Entities
{
    [Table("tb_cl_endereco")]
    public class EnderecoEntity
    {
        [Key]
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public string Complemento { get; set; }
        [ForeignKey(nameof(Usuario))]
        public int UsuarioId { get; set; }
        public virtual UsuarioEntity Usuario { get; set; }
    }
}
