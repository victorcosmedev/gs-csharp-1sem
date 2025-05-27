using GlobalSolution1Sem.Domain.Entities;
using GlobalSolution1Sem.Domain.Interfaces;

namespace GlobalSolution1Sem.Infrastructure.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Task<UsuarioEntity> AddAsync(UsuarioEntity usuario)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string cpf)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UsuarioEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioEntity> GetByCpfAsync(string cpf)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UsuarioEntity>> GetByDataNascimentoAsync(DateTime data)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UsuarioEntity>> GetByNomeAsync(string nome)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioEntity> UpdateAsync(UsuarioEntity usuario)
        {
            throw new NotImplementedException();
        }
    }
}
