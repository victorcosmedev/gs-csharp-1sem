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
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IEnderecoRepository enderecoRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }

        public async Task<UsuarioDto> AtualizarUsuarioAsync(int id, UsuarioDto dto)
        {
            try
            {
                var entity = _mapper.Map<UsuarioEntity>(dto);
                if (dto.EnderecoId.HasValue && dto.EnderecoId > 0)
                {
                    var endereco = await AtribuirEValidarEnderecoIdAsync(id, (int)dto.EnderecoId);
                    entity.EnderecoId = endereco.Id;
                    entity.Endereco = endereco;
                } else
                {
                    entity.Endereco = null;
                    entity.EnderecoId = null;
                }

                entity = await _usuarioRepository.UpdateAsync(id, entity);
                
                return _mapper.Map<UsuarioDto>(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UsuarioDto?> BuscarPorIdAsync(int id)
        {
            var entity = await _usuarioRepository.GetById(id);
            return _mapper.Map<UsuarioDto?>(entity);
        }

        public async Task<UsuarioDto> CadastrarUsuarioAsync(UsuarioDto dto)
        {
            try
            {
                var entity = _mapper.Map<UsuarioEntity>(dto);
                if(dto.EnderecoId != 0 && dto.EnderecoId.HasValue)
                {
                    var endereco = await AtribuirEValidarEnderecoIdAsync(dto.Id, (int)dto.EnderecoId);
                    entity.EnderecoId = endereco.Id;
                    entity.Endereco = endereco;
                } else
                {
                    entity.Endereco = null;
                    entity.EnderecoId = null;
                }

                entity = await _usuarioRepository.AddAsync(entity);
                return _mapper.Map<UsuarioDto>(entity);
            }
            catch(Exception ex)
            {
                throw ex;
            }
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

        private async Task<EnderecoEntity?> AtribuirEValidarEnderecoIdAsync(int usuarioId, int novoEnderecoId)
        {
            var usuario = await _usuarioRepository.GetById(usuarioId);
            if (usuario.EnderecoId != novoEnderecoId)
                throw new Exception("Para alterar o endereço do usuário, altere o usuarioId do endereço");

            return await _enderecoRepository.GetByIdAsync(novoEnderecoId);
        }
    }
}
