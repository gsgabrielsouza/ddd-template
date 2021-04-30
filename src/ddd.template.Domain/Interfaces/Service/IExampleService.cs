using ddd.template.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ddd.template.Domain.Interfaces.Service
{
    public interface IExampleService
    {
        Task<List<Example>> GetBy(int page, int count, string name, decimal? amount);
        Task<Example> GetBy(Guid id);
        Task<Example> Add(Example example);
        Task<Example> Update(Example example);
    }
}
