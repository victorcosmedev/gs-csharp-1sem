using GlobalSolution1Sem.Domain.Entities;
using GlobalSolution1Sem.Domain.Interfaces;
using GlobalSolution1Sem.Infrastructure.Data.AppData;
using Microsoft.EntityFrameworkCore;

namespace GlobalSolution1Sem.Infrastructure.Data.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly ApplicationContext _context;

        public EnderecoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<EnderecoEntity> AddAsync(EnderecoEntity endereco)
        {
            try
            {
                await _context.Endereco.AddAsync(endereco);

                _context.SaveChanges();
                var usuario = await _context.Usuario.FindAsync(endereco.UsuarioId);

                usuario.EnderecoId = endereco.Id;
                usuario.Endereco = endereco;

                _context.SaveChanges();
                return endereco;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var enderecoExistente = await _context.Endereco.FindAsync(id);
            if (enderecoExistente == null)
                throw new Exception("Endereço não existe na base de dados");

            var usuario = await _context.Usuario.FindAsync(enderecoExistente.UsuarioId);
            usuario.Endereco = null;
            usuario.EnderecoId = null;

            _context.Remove(enderecoExistente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<EnderecoEntity>> GetAllAsync()
        {
            return await _context.Endereco.ToListAsync();
        }

        public async Task<EnderecoEntity?> GetByCepAndNumeroAsync(string cep, string numero)
        {
            return await _context.Endereco.FirstOrDefaultAsync(e => e.Cep == cep && e.Numero == numero);
        }

        public async Task<EnderecoEntity?> GetByIdAsync(int id)
        {
            return await _context.Endereco.FindAsync(id);
        }

        public async Task<EnderecoEntity> UpdateAsync(int id, EnderecoEntity endereco)
        {
            if (id != endereco.Id)
                throw new Exception("Não é possível alterar o Id do endereço");
            var enderecoExistente = await _context.Endereco.FindAsync(id);
            if (enderecoExistente == null)
                throw new Exception($"Endereço de id {id} não existe.");

            enderecoExistente.Logradouro = endereco.Logradouro;
            enderecoExistente.Numero = endereco.Numero;
            enderecoExistente.Cep = endereco.Cep;
            enderecoExistente.Complemento = endereco.Complemento;
            await _context.SaveChangesAsync();
            return enderecoExistente;
        }
    }
}
