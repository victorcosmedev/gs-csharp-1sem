namespace GlobalSolution1Sem.Application.Dto
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public int? EnderecoId { get; set; }
    }
}
