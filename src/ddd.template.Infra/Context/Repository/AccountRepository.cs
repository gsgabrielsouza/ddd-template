using ddd.template.Domain.Entities;
using ddd.template.Domain.Interfaces.Repository;

namespace ddd.template.Infra.Context.Repository
{
    /// <summary>
    /// Example Repository
    /// </summary>
    public class AccountRepository : GenericAggragateRepository<Account>, IAccountRepository
    {
        public AccountRepository(ServiceDbContext paymentServiceContext) : base(paymentServiceContext)
        {
        }
    }
}
