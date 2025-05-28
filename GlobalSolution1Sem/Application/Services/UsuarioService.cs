using GlobalSolution1Sem.Application.Interfaces;
using GlobalSolution1Sem.Domain.Entities;

namespace GlobalSolution1Sem.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        public Task<UsuarioEntity> AtualizarUsuarioAsync(UsuarioEntity usuario)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UsuarioEntity>> BuscarUsuariosPorNomeAsync(string nome)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioEntity> CadastrarUsuarioAsync(UsuarioEntity usuario)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UsuarioEntity>> FiltrarUsuariosPorDataNascimentoAsync(DateTime data)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UsuarioEntity>> ListarTodosUsuariosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioEntity> ObterUsuarioPorCpfAsync(string cpf)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoverUsuarioAsync(string cpf)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioEntity> VincularEnderecoUsuarioAsync(string cpf, EnderecoEntity endereco)
        {
            throw new NotImplementedException();
        }
    }
}
