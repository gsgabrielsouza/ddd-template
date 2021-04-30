using System;

namespace ddd.template.Domain.Command.v1
{
    public class ExampleUpdateCommand : BaseCommand
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
    }
}
