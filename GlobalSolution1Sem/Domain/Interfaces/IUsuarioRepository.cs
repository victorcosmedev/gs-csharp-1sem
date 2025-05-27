using GlobalSolution1Sem.Domain.Entities;

namespace GlobalSolution1Sem.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<UsuarioEntity> AddAsync(UsuarioEntity usuario);
        Task<UsuarioEntity> UpdateAsync(UsuarioEntity usuario);
        Task<bool> DeleteAsync(string cpf);
        Task<UsuarioEntity> GetByCpfAsync(string cpf);
        Task<IEnumerable<UsuarioEntity>> GetAllAsync();
        Task<IEnumerable<UsuarioEntity>> GetByNomeAsync(string nome);
        Task<IEnumerable<UsuarioEntity>> GetByDataNascimentoAsync(DateTime data);
    }
}
