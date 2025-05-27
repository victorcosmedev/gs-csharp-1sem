using GlobalSolution1Sem.Domain.Entities;
using GlobalSolution1Sem.Domain.Interfaces;

namespace GlobalSolution1Sem.Infrastructure.Data.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        public Task<EnderecoEntity> AddAsync(EnderecoEntity endereco)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string cep, string numero)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EnderecoEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EnderecoEntity> GetByCepAndNumeroAsync(string cep, string numero)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EnderecoEntity>> GetByLogradouroAsync(string logradouro)
        {
            throw new NotImplementedException();
        }

        public Task<EnderecoEntity> UpdateAsync(EnderecoEntity endereco)
        {
            throw new NotImplementedException();
        }
    }
}
