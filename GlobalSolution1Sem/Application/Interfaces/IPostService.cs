using GlobalSolution1Sem.Domain.Entities;

namespace GlobalSolution1Sem.Application.Interfaces
{
    public interface IPostService
    {
        Task<PostEntity> CriarPostAsync(PostEntity post);
        Task<PostEntity> AtualizarPostAsync(PostEntity post);
        Task<bool> RemoverPostAsync(string titulo);
        Task<PostEntity> ObterPostPorTituloAsync(string titulo);
        Task<IEnumerable<PostEntity>> ListarTodosPostsAsync();
        Task<IEnumerable<PostEntity>> BuscarPostsPorDataAsync(DateTime data);
    }
}
