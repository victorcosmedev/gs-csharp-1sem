using GlobalSolution1Sem.Application.Dto;

namespace GlobalSolution1Sem.Application.Interfaces
{
    public interface IEnderecoService
    {
        Task<EnderecoDto> CadastrarEnderecoAsync(EnderecoDto endereco);
        Task<EnderecoDto> AtualizarEnderecoAsync(EnderecoDto endereco);
        Task<bool> RemoverEnderecoAsync(string cep, string numero);
        Task<EnderecoDto?> ObterEnderecoPorCepNumeroAsync(string cep, string numero);
        Task<EnderecoDto?> BuscarEnderecoPorIdAsync(int id);
        Task<IEnumerable<EnderecoDto>> ListarTodosEnderecosAsync();
    }
}
