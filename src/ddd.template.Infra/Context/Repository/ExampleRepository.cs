using ddd.template.Domain.Entities;
using ddd.template.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public Task<List<Example>> GetBy(int page, int count, string name, decimal? amount)
        {
            var query = _entity.Where(x => x.Name.Contains(name) || x.Amount == amount);
            query = query.Take(count).Skip(page > 1 ? page * count : 0);

            return query.ToListAsync();
        }
    }
}
