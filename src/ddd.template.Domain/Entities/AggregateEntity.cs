using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ddd.template.Domain.Entities
{
    public class AggregateEntity
    {
        private List<string> _errors;

        public AggregateEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            _errors = new List<string>();
        }

        public Guid Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        public DateTime? ModifiedAt { get; protected set; }

        [NotMapped]
        public IReadOnlyList<string> Errors { get => _errors; }

        [NotMapped]
        public virtual bool IsValid => !Errors.Any();

        public void AddError(string message)
        {
            if (!_errors.Contains(message))
                _errors.Add(message);
        }

        protected virtual void Modifield()
        {
            ModifiedAt = DateTime.Now;
        }
    }
}