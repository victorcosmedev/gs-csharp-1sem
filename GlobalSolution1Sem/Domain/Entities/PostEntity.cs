using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution1Sem.Domain.Entities
{
    public class PostEntity
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        [ForeignKey(nameof(Usuario))]
        public int UsuarioId { get; set; }
        public virtual UsuarioEntity Usuario { get; set; }
    }
}
