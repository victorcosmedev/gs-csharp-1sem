using GlobalSolution1Sem.Domain.Entities;
using GlobalSolution1Sem.Domain.Interfaces;

namespace GlobalSolution1Sem.Infrastructure.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        public Task<PostEntity> AddAsync(PostEntity post)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string titulo)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PostEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PostEntity>> GetByDataCriacaoAsync(DateTime data)
        {
            throw new NotImplementedException();
        }

        public Task<PostEntity> GetByTituloAsync(string titulo)
        {
            throw new NotImplementedException();
        }

        public Task<PostEntity> UpdateAsync(PostEntity post)
        {
            throw new NotImplementedException();
        }
    }
}
