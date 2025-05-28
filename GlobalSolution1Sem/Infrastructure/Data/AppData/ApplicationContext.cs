using GlobalSolution1Sem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlobalSolution1Sem.Infrastructure.Data.AppData
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<EnderecoEntity> Endereco { get; set; }
        public DbSet<UsuarioEntity> Usuario { get; set; }
        public DbSet<PostEntity> Post { get; set; }
    }
}
