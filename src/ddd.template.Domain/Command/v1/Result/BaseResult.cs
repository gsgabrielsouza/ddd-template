using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace ddd.template.Domain.Command.v1.Result
{
    public abstract class BaseResult
    {
        [JsonIgnore]
        public List<string> Errors { get; } = new List<string>();

        public bool IsValid => !Errors.Any();
    }
}
