using GlobalSolution1Sem.Domain.Entities;

namespace GlobalSolution1Sem.Application.Interfaces
{
    public interface IEnderecoService
    {
        Task<EnderecoEntity> CadastrarEnderecoAsync(EnderecoEntity endereco);
        Task<EnderecoEntity> AtualizarEnderecoAsync(EnderecoEntity endereco);
        Task<bool> RemoverEnderecoAsync(string cep, string numero);
        Task<EnderecoEntity> ObterEnderecoPorCepNumeroAsync(string cep, string numero);
        Task<IEnumerable<EnderecoEntity>> ListarTodosEnderecosAsync();
        Task<IEnumerable<EnderecoEntity>> BuscarEnderecosPorLogradouroAsync(string logradouro);
    }
}
