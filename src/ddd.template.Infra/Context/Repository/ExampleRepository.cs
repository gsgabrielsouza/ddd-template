using ddd.template.Domain.Entities;
using ddd.template.Domain.Interfaces.Repository;

namespace ddd.template.Infra.Context.Repository
{
    /// <summary>
    /// Example Repository
    /// </summary>
    public class ExampleRepository : GenericAggragateRepository<Example>, IExampleRepository
    {
        public ExampleRepository(ServiceDbContext paymentServiceContext) : base(paymentServiceContext)
        {
        }
    }
}
