using ddd.template.Domain.Interfaces.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace ddd.template.Infra.Context
{
    public class ServiceDbContext : DbContext, IUnitOfWork
    {
        private IDbContextTransaction _transaction;

        // comment this builder when running migrations
        public ServiceDbContext(DbContextOptions options) : base(options)
        {

        }

#if DEBUG
        public ServiceDbContext()
        {

        }
#endif

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public async Task Commit(bool commitTransaction = false)
        {
            if (_transaction != null && commitTransaction)
                await _transaction.CommitAsync();

            await SaveChangesAsync();
        }

        public void OpenTransaction()
        {
            _transaction = Database.BeginTransaction();
        }

        public Task<bool> HealthCheck() => Database.CanConnectAsync();
    }
}
