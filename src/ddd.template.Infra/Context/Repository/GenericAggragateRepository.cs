using ddd.template.Domain.Entities;
using ddd.template.Domain.Interfaces.Repository;
using ddd.template.Domain.Interfaces.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ddd.template.Infra.Context.Repository
{
    public class GenericAggragateRepository<TEntity> : IGenericRepository<TEntity> where TEntity : AggregateEntity
    {
        public readonly IUnitOfWork _unitOfWork;
        protected readonly DbSet<TEntity> _entity;

        public GenericAggragateRepository(ServiceDbContext paymentServiceContext)
        {
            _unitOfWork = paymentServiceContext;
            _entity = paymentServiceContext.Set<TEntity>();
        }

        public IUnitOfWork UnitOfWork => _unitOfWork;

        public void Delete(TEntity entity) => _entity.Remove(entity);

        public void Delete(IEnumerable<TEntity> entity) => _entity.RemoveRange(entity);

        public virtual Task<TEntity> GetBy(Guid id) => _entity.FirstOrDefaultAsync(x => x.Id == id);

        public virtual TEntity Add(TEntity entity) => _entity.Add(entity).Entity;

        public virtual Task Add(IEnumerable<TEntity> entity) => _entity.AddRangeAsync(entity);

        public void Update(TEntity entity) => _entity.Update(entity);

        public void Update(IEnumerable<TEntity> entity) => _entity.UpdateRange(entity);


    }


}