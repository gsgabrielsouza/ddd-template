using System;
using System.Collections.Generic;
using System.Text;

namespace ddd.template.Domain.Command.v1.Query.Result
{
    public class QueryExampleResult
    {
        public QueryExampleResult()
        {
        }

        public QueryExampleResult(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }
        public string Name { get; }
    }
}
