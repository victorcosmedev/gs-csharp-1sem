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

        public Task<EnderecoEntity> AddAsync(EnderecoEntity endereco)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string cep, string numero)
        {
            throw new NotImplementedException();
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
