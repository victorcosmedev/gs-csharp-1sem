using GlobalSolution1Sem.Application.Interfaces;
using GlobalSolution1Sem.Domain.Entities;

namespace GlobalSolution1Sem.Application.Services
{
    public class PostService : IPostService
    {
        public Task<PostEntity> AtualizarPostAsync(PostEntity post)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PostEntity>> BuscarPostsPorDataAsync(DateTime data)
        {
            throw new NotImplementedException();
        }

        public Task<PostEntity> CriarPostAsync(PostEntity post)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PostEntity>> ListarTodosPostsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PostEntity> ObterPostPorTituloAsync(string titulo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoverPostAsync(string titulo)
        {
            throw new NotImplementedException();
        }
    }
}
