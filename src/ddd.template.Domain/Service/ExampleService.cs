using ddd.template.Domain.Entities;
using ddd.template.Domain.Interfaces.Repository;
using ddd.template.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ddd.template.Domain.Service
{
    public class ExampleService : IExampleService
    {
        private readonly IExampleRepository repository;
        public ExampleService(IExampleRepository repository)
        {
            this.repository = repository;
        }

        public Task<Example> Add(Example example)
        {
            throw new NotImplementedException();
        }

        public Task<List<Example>> GetBy(int page, int count, string name, decimal? amount) => repository.GetBy(page, count, name, amount);

        public Task<Example> GetBy(Guid id) => repository.GetBy(id);

        public async Task<Example> Update(Example example)
        {
            // code validations
            //..

            var entitie = await repository.GetBy(example.Id);
            // map object

            repository.Update(entitie);
            return entitie;
        }
    }
}
