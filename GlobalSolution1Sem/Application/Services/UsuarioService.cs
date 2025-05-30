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

        public async Task<UsuarioDto> AtualizarUsuarioAsync(int id, UsuarioDto dto)
        {
            try
            {
                if (dto.EnderecoId.HasValue && dto.EnderecoId > 0)
                {
                    var isEnderecoValid = await ValidarEnderecoIdAsync(id, (int)dto.EnderecoId);
                    if (isEnderecoValid == false)
                        throw new Exception("Para alterar o endereço do usuário, altere o usuarioId do endereço");
                }
                var entity = _mapper.Map<UsuarioEntity>(dto);


            }
            catch (Exception ex)
            {

            }
        }

        public async Task<UsuarioDto?> BuscarPorIdAsync(int id)
        {
            var entity = await _usuarioRepository.GetById(id);
            return _mapper.Map<UsuarioDto?>(entity);
        }

        public Task<UsuarioDto> CadastrarUsuarioAsync(UsuarioDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UsuarioDto>>? ListarTodosUsuariosAsync()
        {
            var entities = await _usuarioRepository.GetAllAsync();
            var dtos = entities.Select(e => _mapper.Map<UsuarioDto>(e)).ToList();
            return dtos;
        }

        public async Task<UsuarioDto?> ObterUsuarioPorCpfAsync(string cpf)
        {
            var entity = await _usuarioRepository.GetByCpfAsync(cpf);
            return _mapper.Map<UsuarioDto?>(entity);
        }

        public async Task<bool> RemoverUsuarioAsync(int id)
        {
            try
            {
                return await _usuarioRepository.DeleteAsync(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private async Task<bool> ValidarEnderecoIdAsync(int usuarioId, int novoEnderecoId)
        {
            var usuario = await _usuarioRepository.GetById(usuarioId);
            if (usuario.EnderecoId != novoEnderecoId)
                return false;
            return true;
        }
    }
}
