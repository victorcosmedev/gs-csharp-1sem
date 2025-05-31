using GlobalSolution1Sem.Domain.Entities;
using GlobalSolution1Sem.Domain.Interfaces;
using GlobalSolution1Sem.Infrastructure.Data.AppData;
using Microsoft.EntityFrameworkCore;

namespace GlobalSolution1Sem.Infrastructure.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationContext _context;

        public PostRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<PostEntity> AddAsync(PostEntity post)
        {
            try
            {
                await _context.Post.AddAsync(post);
                var usuario = await _context.Usuario.FindAsync(post.UsuarioId);
                _context.SaveChanges();

                usuario.Posts.Add(post);
                _context.SaveChanges();
                return post;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var postExistente = await _context.Post.FindAsync(id);
            if (postExistente == null)
                throw new Exception("Post não existe na base de dados");

            _context.Post.Remove(postExistente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<PostEntity>> GetAllAsync()
        {
            return await _context.Post.ToListAsync();
        }

        public async Task<PostEntity?> GetByIdAsync(int id)
        {
            return await _context.Post.FindAsync(id);
        }

        public async Task<IEnumerable<PostEntity>>? GetByUsuarioIdAsync(int usuarioId)
        {
            return _context.Post.ToList().Where(p => p.UsuarioId == usuarioId);
        }

        public async Task<PostEntity> UpdateAsync(int id, PostEntity post)
        {
            if (id != post.Id)
                throw new("Não é possível alterar o Id do post");
            
            var postExistente = await _context.Post.FindAsync(id);
            if (postExistente == null)
                throw new Exception($"Post de id {id} não existe.");

            postExistente.Titulo = post.Titulo;
            postExistente.Descricao = post.Descricao;
            await _context.SaveChangesAsync();
            return postExistente;
        }
    }
}
