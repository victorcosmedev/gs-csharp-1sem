namespace GlobalSolution1Sem.Application.Dto
{
    public class EnderecoDto
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public string Complemento { get; set; }
        public int UsuarioId { get; set; }
    }
}
