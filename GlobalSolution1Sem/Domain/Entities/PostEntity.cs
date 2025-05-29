using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution1Sem.Domain.Entities
{
    [Table("tb_cl_post")]
    public class PostEntity
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        [ForeignKey(nameof(Usuario))]
        public int UsuarioId { get; set; }
        public virtual UsuarioEntity Usuario { get; set; }
    }
}
