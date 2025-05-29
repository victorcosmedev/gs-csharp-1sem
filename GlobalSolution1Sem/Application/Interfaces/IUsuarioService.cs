using GlobalSolution1Sem.Application.Dto;

namespace GlobalSolution1Sem.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDto> CadastrarUsuarioAsync(UsuarioDto dto);
        Task<UsuarioDto> AtualizarUsuarioAsync(UsuarioDto dto);
        Task<bool> RemoverUsuarioAsync(string cpf);
        Task<UsuarioDto?> ObterUsuarioPorCpfAsync(string cpf);
        Task<IEnumerable<UsuarioDto>>? ListarTodosUsuariosAsync();
        Task<UsuarioDto?> BuscarPorIdAsync(int id);
    }
}
