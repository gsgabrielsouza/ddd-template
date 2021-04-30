using System.Threading.Tasks;

namespace ddd.template.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task Commit(bool commitTransaction = false);

        void OpenTransaction();
        Task<bool> HealthCheck();
    }
}