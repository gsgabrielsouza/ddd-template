using ddd.template.Domain.Command.v1;
using ddd.template.Domain.Command.v1.Query.Result;
using ddd.template.Domain.Command.v1.Result;
using ddd.template.Domain.Entities;
using ddd.template.Domain.Interfaces.Repository;
using ddd.template.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ddd.template.Application.Service.v1
{
    public class ExampleAppService
    {
        private readonly IExampleService service;

        public ExampleAppService(IExampleService service)
        {
            this.service = service;
        }

        public async Task<IEnumerable<QueryExampleResult>> GetBy(int page, int count, string name, decimal? amount)
        {
            List<Example> entities = await service.GetBy(page, count, name, amount);

            if (!entities.Any())
                return Enumerable.Empty<QueryExampleResult>();

            return entities.Select(x => new QueryExampleResult(x.Id, x.Name));
        }

        public async Task<QueryExampleResult> GetBy(Guid id)
        {
            Example example = await service.GetBy(id);
            if (example == null)
                return null;

            return new QueryExampleResult(example.Id, example.Name);
        }

        public async Task<ExampleAddResult> Add(ExampleAddCommand command)
        {
            Example example = await service.Add(new Example(command.Name));
            if (example.Errors.Any())
                return new ExampleAddResult(example.Errors);

            return new ExampleAddResult(example.Name);
        }

        public async Task<ExampleUpdateResult> Update(ExampleUpdateCommand command)
        {
            Example example = await service.Update(new Example(command.Id, command.Name));
            if (example.Errors.Any())
                return new ExampleUpdateResult(example.Errors);

            return new ExampleUpdateResult(example.Name);
        }
    }
}
