using System;

namespace ddd.template.Domain.Entities
{
    public class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; protected set; }
    }

    public class Entity<TIdentifier>
    {
        public Entity()
        {
        }

        public Entity(TIdentifier id) => Id = id;

        public TIdentifier Id { get; protected set; }
    }
}