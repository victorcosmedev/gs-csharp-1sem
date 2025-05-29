using GlobalSolution1Sem.Domain.Entities;

namespace GlobalSolution1Sem.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<UsuarioEntity> AddAsync(UsuarioEntity usuario);
        Task<UsuarioEntity> UpdateAsync(int id, UsuarioEntity usuario);
        Task<bool> DeleteAsync(int id);
        Task<UsuarioEntity?> GetByCpfAsync(string cpf);
        Task<IEnumerable<UsuarioEntity>> GetAllAsync();
        Task<UsuarioEntity?> GetById(int id);
    }
}
