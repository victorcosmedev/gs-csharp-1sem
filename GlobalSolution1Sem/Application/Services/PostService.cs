using AutoMapper;
using GlobalSolution1Sem.Application.Dto;
using GlobalSolution1Sem.Application.Interfaces;
using GlobalSolution1Sem.Domain.Entities;
using GlobalSolution1Sem.Domain.Interfaces;

namespace GlobalSolution1Sem.Application.Services
{
    public class PostService : IPostService
    {

        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public Task<PostDto> AtualizarPostAsync(PostDto post)
        {
            throw new NotImplementedException();
        }

        public Task<PostDto?> BuscarPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PostDto>> BuscarPorUsuarioIdAsync(int usuarioId)
        {
            throw new NotImplementedException();
        }

        public Task<PostDto> CriarPostAsync(PostDto post)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PostDto>> ListarTodosPostsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoverPostAsync(string titulo)
        {
            throw new NotImplementedException();
        }
    }
}
