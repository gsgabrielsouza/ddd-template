using ddd.template.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ddd.template.Domain.Interfaces.Repository
{
    public interface IExampleRepository : IGenericRepository<Example>
    {
        Task<List<Example>> GetBy(int page, int count, string name, decimal? amount);
    }
}
