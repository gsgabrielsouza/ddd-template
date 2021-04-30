using System.Collections.Generic;

namespace ddd.template.Domain.Command.v1.Result
{
    public class ExampleUpdateResult : BaseResult
    {
        public ExampleUpdateResult(IReadOnlyList<string> errors)
        {
            Errors = errors;
        }

        public ExampleUpdateResult(string name)
        {
            Name = name;
        }

        public IReadOnlyList<string> Errors { get; }
        public string Name { get; }
    }
}
