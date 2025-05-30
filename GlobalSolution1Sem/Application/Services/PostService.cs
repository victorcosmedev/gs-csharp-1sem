using AutoMapper;
using GlobalSolution1Sem.Application.Dto;
using GlobalSolution1Sem.Application.Interfaces;
using GlobalSolution1Sem.Domain.Entities;
using GlobalSolution1Sem.Domain.Interfaces;
using GlobalSolution1Sem.Infrastructure.Data.Repositories;

namespace GlobalSolution1Sem.Application.Services
{
    public class PostService : IPostService
    {

        private readonly IPostRepository _postRepository;
        private readonly IUsuarioRepository _usuarioRepository;  
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository, IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<PostDto> AtualizarPostAsync(int id, PostDto post)
        {
            try
            {
                var entity = _mapper.Map<PostEntity>(post);
                var usuario = await AtribuirEValidarUsuarioAsync(post.UsuarioId, entity.UsuarioId);
                entity.Usuario = usuario;

                entity = await _postRepository.UpdateAsync(id, entity);
                return _mapper.Map<PostDto>(entity);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PostDto?> BuscarPorIdAsync(int id)
        {
            var entity = await _postRepository.GetByIdAsync(id);
            return _mapper.Map<PostDto?>(entity);
        }

        public async Task<IEnumerable<PostDto>> BuscarPorUsuarioIdAsync(int usuarioId)
        {
            var postsEntity = await _postRepository.GetByUsuarioIdAsync(usuarioId);
            var postsDto = postsEntity.Select(p => _mapper.Map<PostDto>(p)).ToList();
            return postsDto;
        }

        public async Task<PostDto> CriarPostAsync(PostDto post)
        {
            try
            {
                var entity = _mapper.Map<PostEntity>(post);
                var usuario = await AtribuirEValidarUsuarioAsync(post.UsuarioId, post.Id);
                entity.Usuario = usuario;

                entity = await _postRepository.AddAsync(entity);
                return _mapper.Map<PostDto>(entity);
            } 
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<PostDto>> ListarTodosPostsAsync()
        {
            var entities = await _postRepository.GetAllAsync();
            var dtos = entities.Select(e => _mapper.Map<PostDto?>(e)).ToList();
            return dtos;
        }

        public async Task<bool> RemoverPostAsync(int id)
        {
            try
            {
                return await _postRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<UsuarioEntity> AtribuirEValidarUsuarioAsync(int usuarioId, int postId)
        {
            var usuario = await _usuarioRepository.GetById(usuarioId);
            if (usuario == null)
                throw new Exception("Usuário não existe");

            return usuario;
        }
    }
}
