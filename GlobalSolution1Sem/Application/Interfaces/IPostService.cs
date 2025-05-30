using GlobalSolution1Sem.Application.Dto;

namespace GlobalSolution1Sem.Application.Interfaces
{
    public interface IPostService
    {
        Task<PostDto> CriarPostAsync(PostDto post);
        Task<PostDto> AtualizarPostAsync(int id, PostDto post);
        Task<bool> RemoverPostAsync(int id);
        Task<IEnumerable<PostDto>> BuscarPorUsuarioIdAsync(int usuarioId);
        Task<IEnumerable<PostDto>> ListarTodosPostsAsync();
        Task<PostDto?> BuscarPorIdAsync(int id);
    }
}
