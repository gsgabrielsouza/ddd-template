using ddd.template.Domain.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ddd.template.Domain.Interfaces.Repository
{
    public class GenericEntityRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
    {
        public readonly IUnitOfWork _unitOfWork;
        protected readonly DbSet<TEntity> _entity;

        public GenericEntityRepository(ServiceDbContext paymentServiceContext)
        {
            _unitOfWork = paymentServiceContext;
            _entity = paymentServiceContext.Set<TEntity>();
        }

        public IUnitOfWork UnitOfWork => _unitOfWork;

        public void Delete(TEntity entity) => _entity.Remove(entity);

        public void Delete(IEnumerable<TEntity> entity) => _entity.RemoveRange(entity);

        public Task<TEntity> GetBy(Guid id) => _entity.FirstOrDefaultAsync(x => x.Id == id);

        public TEntity Add(TEntity entity) => _entity.Add(entity).Entity;

        public Task Add(IEnumerable<TEntity> entity) => _entity.AddRangeAsync(entity);

        public virtual void Update(TEntity entity) => _entity.Update(entity);
        public virtual void Update(IEnumerable<TEntity> entity) => _entity.UpdateRange(entity);
    }
}
