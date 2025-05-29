using GlobalSolution1Sem.Domain.Entities;

namespace GlobalSolution1Sem.Domain.Interfaces
{
    public interface IEnderecoRepository
    {
        Task<EnderecoEntity> AddAsync(EnderecoEntity endereco);
        Task<EnderecoEntity> UpdateAsync(int id, EnderecoEntity endereco);
        Task<bool> DeleteAsync(int id);
        Task<EnderecoEntity> GetByCepAndNumeroAsync(string cep, string numero);
        Task<EnderecoEntity?> GetByIdAsync(int id);
        Task<IEnumerable<EnderecoEntity>> GetAllAsync();
    }
}
