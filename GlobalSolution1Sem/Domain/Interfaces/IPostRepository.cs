using GlobalSolution1Sem.Domain.Entities;

namespace GlobalSolution1Sem.Domain.Interfaces
{
    public interface IPostRepository
    {
        Task<PostEntity> AddAsync(PostEntity post);
        Task<PostEntity> UpdateAsync(PostEntity post);
        Task<bool> DeleteAsync(string titulo);
        Task<PostEntity> GetByTituloAsync(string titulo);
        Task<IEnumerable<PostEntity>> GetAllAsync();
        Task<IEnumerable<PostEntity>> GetByDataCriacaoAsync(DateTime data);
    }
}
