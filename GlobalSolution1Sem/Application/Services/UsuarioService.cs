using AutoMapper;
using GlobalSolution1Sem.Application.Dto;
using GlobalSolution1Sem.Application.Interfaces;
using GlobalSolution1Sem.Domain.Entities;
using GlobalSolution1Sem.Domain.Interfaces;

namespace GlobalSolution1Sem.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public Task<UsuarioDto> AtualizarUsuarioAsync(UsuarioDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioDto?> BuscarPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioDto> CadastrarUsuarioAsync(UsuarioDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UsuarioDto>>? ListarTodosUsuariosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioDto?> ObterUsuarioPorCpfAsync(string cpf)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoverUsuarioAsync(string cpf)
        {
            throw new NotImplementedException();
        }
    }
}
