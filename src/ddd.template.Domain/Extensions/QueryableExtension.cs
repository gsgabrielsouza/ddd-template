using System;
using System.Linq;
using System.Linq.Expressions;

namespace ddd.template.Domain.Extensions
{
    public static class QueryableExtension
    {
        public static IQueryable<TEntity> Filter<TEntity>(
             this IQueryable<TEntity> query, Expression<Func<TEntity, bool>> expressionCondition)
        {
            return query.Where(expressionCondition);
        }

        public static IQueryable<TEntity> Filter<TEntity>(
            this IQueryable<TEntity> query, Expression<Func<TEntity, bool>> expressionCondition, Expression<Func<bool>> conditionAttribute)
        {
            var func = conditionAttribute.Compile();
            bool canAssingValue = (bool)func();
            if (canAssingValue)
            {
                return query.Filter(expressionCondition);
            }

            return query;
        }
    }
}
