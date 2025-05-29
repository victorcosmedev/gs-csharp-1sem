using GlobalSolution1Sem.Application.Dto;

namespace GlobalSolution1Sem.Application.Interfaces
{
    public interface IPostService
    {
        Task<PostDto> CriarPostAsync(PostDto post);
        Task<PostDto> AtualizarPostAsync(PostDto post);
        Task<bool> RemoverPostAsync(string titulo);
        Task<IEnumerable<PostDto>> BuscarPorUsuarioIdAsync(int usuarioId);
        Task<IEnumerable<PostDto>> ListarTodosPostsAsync();
        Task<PostDto?> BuscarPorIdAsync(int id);
    }
}
