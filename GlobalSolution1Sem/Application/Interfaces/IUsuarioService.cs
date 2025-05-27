using GlobalSolution1Sem.Domain.Entities;

namespace GlobalSolution1Sem.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioEntity> CadastrarUsuarioAsync(UsuarioEntity usuario);
        Task<UsuarioEntity> AtualizarUsuarioAsync(UsuarioEntity usuario);
        Task<bool> RemoverUsuarioAsync(string cpf);
        Task<UsuarioEntity> ObterUsuarioPorCpfAsync(string cpf);
        Task<IEnumerable<UsuarioEntity>> ListarTodosUsuariosAsync();
        Task<IEnumerable<UsuarioEntity>> BuscarUsuariosPorNomeAsync(string nome);
        Task<IEnumerable<UsuarioEntity>> FiltrarUsuariosPorDataNascimentoAsync(DateTime data);

        // Método específico para vincular um endereço ao usuário
        Task<UsuarioEntity> VincularEnderecoUsuarioAsync(string cpf, EnderecoEntity endereco);
    }
}
