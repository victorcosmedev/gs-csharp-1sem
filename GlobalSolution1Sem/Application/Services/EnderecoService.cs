using AutoMapper;
using GlobalSolution1Sem.Application.Dto;
using GlobalSolution1Sem.Application.Interfaces;
using GlobalSolution1Sem.Domain.Entities;
using GlobalSolution1Sem.Domain.Interfaces;

namespace GlobalSolution1Sem.Application.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public EnderecoService(IEnderecoRepository enderecoRepository, IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _enderecoRepository = enderecoRepository;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<EnderecoDto> AtualizarEnderecoAsync(int id, EnderecoDto endereco)
        {
            try
            {
                var entity = _mapper.Map<EnderecoEntity>(endereco);
                var usuario = await AtribuirEValidarUsuarioAsync(endereco.UsuarioId, entity);
                entity.Usuario = usuario;

                entity = await _enderecoRepository.UpdateAsync(id, entity);

                return _mapper.Map<EnderecoDto>(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<EnderecoDto?> BuscarEnderecoPorIdAsync(int id)
        {
            var entity = await _enderecoRepository.GetByIdAsync(id);
            var dto = _mapper.Map<EnderecoDto>(entity);
            return dto;
        }

        public async Task<EnderecoDto> CadastrarEnderecoAsync(EnderecoDto endereco)
        {
            try
            {
                var entity = _mapper.Map<EnderecoEntity>(endereco);
                var usuario = await AtribuirEValidarUsuarioAsync(endereco.UsuarioId, entity);
                entity.Usuario = usuario;

                entity = await _enderecoRepository.AddAsync(entity);
                return _mapper.Map<EnderecoDto>(entity);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<EnderecoDto>> ListarTodosEnderecosAsync()
        {
            var entities = await _enderecoRepository.GetAllAsync();
            var dtos = entities.Select(e => _mapper.Map<EnderecoDto>(e)).ToList();
            return dtos;
        }

        public async Task<EnderecoDto?> ObterEnderecoPorCepNumeroAsync(string cep, string numero)
        {
            var entity = await _enderecoRepository.GetByCepAndNumeroAsync(cep, numero);
            var dto = _mapper.Map<EnderecoDto?> (entity);
            return dto;
        }

        public async Task<bool> RemoverEnderecoAsync(int id)
        {
            try
            {
                return await _enderecoRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<UsuarioEntity> AtribuirEValidarUsuarioAsync(int usuarioId, EnderecoEntity entity)
        {
            var usuario = await _usuarioRepository.GetById(usuarioId);
            if (usuario == null)
                throw new Exception("Usuário não existe");

            if (usuario.EnderecoId > 0 && usuario.EnderecoId != entity.Id)
                throw new Exception("Usuário já está cadastrado num endereço");

            return usuario;
        }
    }
}
