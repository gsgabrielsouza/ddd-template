using System;

namespace ddd.template.Domain.Entities
{
    /// <summary>
    /// Entitie Example
    /// </summary>
    public class Example : AggregateEntity
    {
        public Example(string name)
        {
            Name = name;
        }

        public Example(Guid id, string name) : this(name)
        {
            Id = id;
        }

        public string Name { get; private set; }
        public decimal? Amount { get; set; }
    }
}
