using GlobalSolution1Sem.Domain.Entities;

namespace GlobalSolution1Sem.Domain.Interfaces
{
    public interface IEnderecoRepository
    {
        Task<EnderecoEntity> AddAsync(EnderecoEntity endereco);
        Task<EnderecoEntity> UpdateAsync(EnderecoEntity endereco);
        Task<bool> DeleteAsync(string cep, string numero);
        Task<EnderecoEntity> GetByCepAndNumeroAsync(string cep, string numero);
        Task<IEnumerable<EnderecoEntity>> GetAllAsync();
        Task<IEnumerable<EnderecoEntity>> GetByLogradouroAsync(string logradouro);
    }
}
