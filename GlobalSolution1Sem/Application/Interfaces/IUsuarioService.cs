using GlobalSolution1Sem.Application.Dto;

namespace GlobalSolution1Sem.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDto> CadastrarUsuarioAsync(UsuarioDto dto);
        Task<UsuarioDto> AtualizarUsuarioAsync(int id, UsuarioDto dto);
        Task<bool> RemoverUsuarioAsync(int id);
        Task<UsuarioDto?> ObterUsuarioPorCpfAsync(string cpf);
        Task<IEnumerable<UsuarioDto>>? ListarTodosUsuariosAsync();
        Task<UsuarioDto?> BuscarPorIdAsync(int id);
    }
}
