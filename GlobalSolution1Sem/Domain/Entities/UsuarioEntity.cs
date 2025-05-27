namespace GlobalSolution1Sem.Domain.Entities
{
    public class UsuarioEntity
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public EnderecoEntity Endereco { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
