using ddd.template.Domain.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ddd.template.Domain.Interfaces.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public IUnitOfWork UnitOfWork { get; }

        Task<TEntity> GetBy(Guid id);

        void Delete(TEntity entity);

        void Delete(IEnumerable<TEntity> entity);

        TEntity Add(TEntity entity);

        Task Add(IEnumerable<TEntity> entity);

        void Update(TEntity entity);

        void Update(IEnumerable<TEntity> entity);
    }
}