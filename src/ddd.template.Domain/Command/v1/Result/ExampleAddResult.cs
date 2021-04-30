using System.Collections.Generic;

namespace ddd.template.Domain.Command.v1.Result
{
    public class ExampleAddResult : BaseResult
    {
        public ExampleAddResult(IReadOnlyList<string> errors)
        {
            Errors = errors;
        }

        public ExampleAddResult(string name)
        {
            Name = name;
        }

        public IReadOnlyList<string> Errors { get; }
        public string Name { get; }
    }
}
