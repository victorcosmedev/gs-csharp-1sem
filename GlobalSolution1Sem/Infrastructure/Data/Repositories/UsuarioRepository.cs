using GlobalSolution1Sem.Domain.Entities;
using GlobalSolution1Sem.Domain.Interfaces;
using GlobalSolution1Sem.Infrastructure.Data.AppData;
using Microsoft.EntityFrameworkCore;

namespace GlobalSolution1Sem.Infrastructure.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationContext _context;

        public UsuarioRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<UsuarioEntity> AddAsync(UsuarioEntity usuario)
        {
            try
            {
                await _context.Usuario.AddAsync(usuario);
                _context.SaveChanges();
                return usuario;
            } 
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var usuarioExistente = _context.Usuario.Find(id);
            if (usuarioExistente == null)
                throw new Exception("Usuário não existe na base de dados");
            
            _context.Usuario.Remove(usuarioExistente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<UsuarioEntity>> GetAllAsync()
        {
            return await _context.Usuario.ToListAsync();
        }

        public Task<UsuarioEntity?> GetByCpfAsync(string cpf)
        {
            return _context.Usuario.FirstOrDefaultAsync(x => x.Cpf == cpf);
        }

        public async Task<UsuarioEntity?> GetById(int id)
        {
            return await _context.Usuario.FindAsync(id);
        }

        public async Task<UsuarioEntity> UpdateAsync(int id, UsuarioEntity usuario)
        {
            if (id != usuario.Id)
                throw new Exception("Não é possível alterar o Id do usuário");

            var usuarioExistente = _context.Usuario.Find(id);
            if (usuarioExistente == null)
                throw new Exception($"Usuário de id {id} não existe.");

            usuarioExistente.Nome = usuario.Nome;
            usuarioExistente.Cpf = usuario.Cpf;
            usuarioExistente.DataNascimento = usuario.DataNascimento;
            await _context.SaveChangesAsync();
            return usuarioExistente;
        }
    }
}
