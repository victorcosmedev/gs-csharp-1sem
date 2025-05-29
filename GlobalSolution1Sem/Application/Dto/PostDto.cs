namespace GlobalSolution1Sem.Application.Dto
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public int UsuarioId { get; set; }
    }
}
