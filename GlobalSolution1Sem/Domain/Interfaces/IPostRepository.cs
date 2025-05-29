using GlobalSolution1Sem.Domain.Entities;

namespace GlobalSolution1Sem.Domain.Interfaces
{
    public interface IPostRepository
    {
        Task<PostEntity> AddAsync(PostEntity post);
        Task<PostEntity> UpdateAsync(int id, PostEntity post);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<PostEntity>> GetByUsuarioIdAsync(int usuarioId);
        Task<IEnumerable<PostEntity>> GetAllAsync();
        Task<PostEntity?> GetByIdAsync(int id);
    }
}
