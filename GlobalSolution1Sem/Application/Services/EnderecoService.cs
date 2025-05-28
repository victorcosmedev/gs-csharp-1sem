using GlobalSolution1Sem.Application.Interfaces;
using GlobalSolution1Sem.Domain.Entities;

namespace GlobalSolution1Sem.Application.Services
{
    public class EnderecoService : IEnderecoService
    {
        public Task<EnderecoEntity> AtualizarEnderecoAsync(EnderecoEntity endereco)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EnderecoEntity>> BuscarEnderecosPorLogradouroAsync(string logradouro)
        {
            throw new NotImplementedException();
        }

        public Task<EnderecoEntity> CadastrarEnderecoAsync(EnderecoEntity endereco)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EnderecoEntity>> ListarTodosEnderecosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EnderecoEntity> ObterEnderecoPorCepNumeroAsync(string cep, string numero)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoverEnderecoAsync(string cep, string numero)
        {
            throw new NotImplementedException();
        }
    }
}
